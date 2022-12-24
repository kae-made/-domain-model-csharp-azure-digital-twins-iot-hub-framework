using Azure;
using Azure.DigitalTwins.Core;
using Microsoft.Azure.DigitalTwins.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kae.DomainModel.Csharp.AzureDigitalTwins.Timer
{
    internal class DTDLRepository
    {
        DigitalTwinsClient adtClient;
        Dictionary<string, DTInterfaceInfo> dtdlInterfaces = new Dictionary<string, DTInterfaceInfo>();
        Dictionary<string, DTInterfaceInfo> dtdlInterfacesForTelemetry = new Dictionary<string, DTInterfaceInfo>();
        Dictionary<string, string> idPropForDtdlInterfaces = new Dictionary<string, string>();

        public DTDLRepository(DigitalTwinsClient adtClient)
        {
            this.adtClient = adtClient;
        }

        public async Task<string> GetModelIdForTelemetry(string telemetryName)
        {
            string modelId = null;
            if (dtdlInterfacesForTelemetry.ContainsKey(telemetryName))
            {
                modelId = dtdlInterfacesForTelemetry[telemetryName].Id.AbsolutePath;
            }
            else
            {
                if (dtdlInterfaces.Count == 0)
                {
                    AsyncPageable<DigitalTwinsModelData> models = adtClient.GetModelsAsync(new GetModelsOptions() { IncludeModelDefinition = true });
                    var modelsJson = new List<string>();
                    await foreach (var model in models)
                    {
                        var id = model.Id;
                        string displayName = model.LanguageDisplayNames.Values.First();
                        if (!string.IsNullOrEmpty(model.DtdlModel))
                        {
                            modelsJson.Add(model.DtdlModel);
                        }
                    }
                    var parser = new ModelParser();
                    var parseResultForJson = await parser.ParseAsync(modelsJson);
                    foreach (var declKey in parseResultForJson.Keys)
                    {
                        var declFrag = parseResultForJson[declKey];
                        if (declFrag != null)
                        {
                            switch (declFrag.EntityKind)
                            {
                                case DTEntityKind.Interface:
                                    var declInterface = (DTInterfaceInfo)declFrag;
                                    dtdlInterfaces.Add(declInterface.Id.AbsolutePath, declInterface);

                                    foreach(var ck in declInterface.Contents.Keys)
                                    {
                                        var c = declInterface.Contents[ck];
                                        if (c.EntityKind== DTEntityKind.Property)
                                        {
                                            var propDef = (DTPropertyInfo)c;
                                            if (propDef.Comment.IndexOf("@I0") >= 0)
                                            {
                                                idPropForDtdlInterfaces.Add(declInterface.Id.AbsolutePath, propDef.Name);
                                                break;
                                            }
                                        }
                                    }

                                    break;
                            }
                        }
                    }
                    foreach (var ifKey in dtdlInterfaces.Keys)
                    {
                        var dtdlIf = dtdlInterfaces[ifKey];
                        foreach (var ck in dtdlIf.Contents.Keys)
                        {
                            var c = dtdlIf.Contents[ck];
                            if (c.EntityKind == DTEntityKind.Telemetry)
                            {
                                if (c.Name == telemetryName)
                                {
                                    if (!dtdlInterfacesForTelemetry.ContainsKey(telemetryName))
                                    {
                                        dtdlInterfacesForTelemetry.Add(telemetryName, dtdlIf);
                                        modelId = dtdlIf.Id.AbsolutePath;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                if (string.IsNullOrEmpty(modelId))
                {
                    modelId = dtdlInterfacesForTelemetry[telemetryName].Id.AbsolutePath;
                }
            }
            if (!modelId.StartsWith("dtmi:"))
            {
                modelId = $"dtmi:{modelId}";
            }
            return modelId;
        }

        public string GetIdentityPropName(string modelId)
        {
            return idPropForDtdlInterfaces[modelId];
        }
    }
}
