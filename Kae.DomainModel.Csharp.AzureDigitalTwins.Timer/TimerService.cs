using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.DigitalTwins.Core;
using Azure.Identity;
using Kae.DomainModel.CSharp.Framework.Service.Event;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Kae.DomainModel.Csharp.AzureDigitalTwins.Timer
{
    public static class TimerService
    {
        [FunctionName("TimerService")]
        public static async Task RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context,
            ILogger logger)
        {
            var evtTimerOp = context.GetInput<EventTimerOperation>();
            var timerEntryId = new EntityId(nameof(TimerEntry), context.InstanceId);
            await context.CallEntityAsync(timerEntryId, "SetState", (context.InstanceId, evtTimerOp.FireTime));

            var cancelEvent = context.WaitForExternalEvent("Cancel");
            using (var cts = new CancellationTokenSource())
            {
                bool finished = false;
                var timerTask = context.CreateTimer(evtTimerOp.FireTime, cts.Token);
                var winner = await Task.WhenAny(timerTask, cancelEvent);
                if (winner == timerTask)
                {
                    logger.LogInformation($"Time has come - {context.InstanceId}");
                    await context.CallActivityAsync("TimerFired", evtTimerOp);
                    finished = true;
                }
                else if (winner == cancelEvent)
                {
                    logger.LogInformation($"Timer canceld - {context.InstanceId}");
                    finished = true;
                }
                else
                {
                    logger.LogError($"Unknown task for {context.InstanceId} - {winner.ToString()}");
                }
                if (finished)
                {
                    await context.CallEntityAsync(timerEntryId, "Delete");
                }
            }
        }

        [FunctionName("CancelTimer")]
        public static async Task<HttpResponseMessage> CancelTimer(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestMessage req,
            [DurableClient] IDurableOrchestrationClient client, ILogger log)
        {
            var instanceId = req.RequestUri.ParseQueryString()["timerid"];
            log.LogInformation($"Timer canceling... - {instanceId}");
            await client.RaiseEventAsync(instanceId, "Cacnel");
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

        [FunctionName("TimerFired")]
        public static async Task TimerFired([ActivityTrigger] IDurableActivityContext context, ILogger log)
        {
            log.LogInformation($"Timer Fired - {context.InstanceId}");
            var evtTimerOp = context.GetInput<EventTimerOperation>();
            var adtClient = GetADTClient();
            if (string.IsNullOrEmpty(evtTimerOp.DestinationIdentities))
            {
                var modelId = await dtdlRepository.GetModelIdForTelemetry(evtTimerOp.EventLabel);
                var idPropName = dtdlRepository.GetIdentityPropName(modelId);
                var twinContent = new Dictionary<string, object>();
                string twinId = Guid.NewGuid().ToString();
                twinContent.Add(idPropName, twinId);
                evtTimerOp.DestinationIdentities = $"{idPropName}={twinId}";
                twinId = evtTimerOp.DestinationIdentities;
                var newTine = new BasicDigitalTwin()
                {
                    Id = twinId,
                    Metadata = { ModelId = modelId },
                    Contents = twinContent
                };
                await adtClient.CreateOrReplaceDigitalTwinAsync<BasicDigitalTwin>(twinId, newTine);
                log.LogInformation($"Created twin[{twinId}] for creation event - {evtTimerOp.EventLabel}");
            }
            string evtData = Newtonsoft.Json.JsonConvert.SerializeObject(evtTimerOp.Parameters);
            await adtClient.PublishTelemetryAsync(evtTimerOp.DestinationIdentities, context.InstanceId, evtData);
            log.LogInformation($"Published - {evtTimerOp.EventLabel}");
        }

        [FunctionName("TimerStatus")]
        public static async Task<HttpResponseMessage> TimerOperation(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestMessage req,
            [DurableClient] IDurableEntityClient client, ILogger log)
        {
            var instanceId = req.RequestUri.ParseQueryString()["timerid"];

            var timerEntityId = new EntityId(nameof(TimerEntry), instanceId);
            var timerEntity = await client.ReadEntityStateAsync<TimerEntry>(timerEntityId);
            EventTimerResponse response = new EventTimerResponse() { TimerId = instanceId, WaitForFire=timerEntity.EntityExists };

            if (timerEntity.EntityExists)
            {
                log.LogInformation($"Getting remain time - {instanceId}");
                response.RemainingTime = timerEntity.EntityState.FireTime;
            }
            else
            {
                log.LogInformation($"Timer has been expired - {instanceId}");
            }
            return req.CreateResponse(System.Net.HttpStatusCode.OK, response, "text/json");
        }


        [FunctionName("TimerService_HttpStart")]
        public static async Task<HttpResponseMessage> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestMessage req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            EventTimerOperation evtTimerOp = null;
            // Function input comes from the request content.
            using (var reader = new StreamReader(req.Content.ReadAsStream()))
            {
                string eventParamsJson = reader.ReadToEnd();
                evtTimerOp = Newtonsoft.Json.JsonConvert.DeserializeObject<EventTimerOperation>(eventParamsJson);
            }

            string instanceId = await starter.StartNewAsync<EventTimerOperation>("TimerService", evtTimerOp.TimerId, evtTimerOp);

            log.LogInformation($"Started Time Service orchestration with ID = '{instanceId}'.");

            return starter.CreateCheckStatusResponse(req, instanceId);
        }

        private static DigitalTwinsClient adtClient = null;
        static readonly HttpClient httpClient = new HttpClient();
        private static DigitalTwinsClient GetADTClient()
        {
            if (adtClient == null)
            {
                var configuration = new ConfigurationBuilder().AddJsonFile("local.settings.json", true).AddEnvironmentVariables().Build();
                string adtUrl = configuration.GetConnectionString("ADT");
                // var credential = new ManagedIdentityCredential("https://digitaltwins.azure.net");
                var credential = new DefaultAzureCredential();
                adtClient = new DigitalTwinsClient(new Uri(adtUrl), credential,
                        new DigitalTwinsClientOptions
                        {
                            Transport = new HttpClientTransport(httpClient)
                        });
                dtdlRepository = new DTDLRepository(adtClient);
            }
            return adtClient;
        }
        static DTDLRepository dtdlRepository;
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class TimerEntry
    {
        [JsonProperty("TimerId")]
        public string TimerId { get; set; }
        [JsonProperty("FireTime")]
        public DateTime FireTime { get; set; }

        public void SetState((string timerId, DateTime fireTime) timerParams)
        {
            TimerId = timerParams.timerId;
            FireTime = timerParams.fireTime;
        }

        public void Delete()
        {
            Entity.Current.DeleteState();
        }

        [FunctionName(nameof(TimerEntry))]
        public static Task Run([EntityTrigger] IDurableEntityContext context) => context.DispatchAsync<TimerEntry>();
    }
}

