using Azure;
using Azure.DigitalTwins.Core;
using Microsoft.Azure.DigitalTwins.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kae.DomainMode.Csharp.AzureDigitalTwins.AzureIoTHubBinder
{
    internal class DTDLRepository
    {
        DigitalTwinsClient adtClient;
        Dictionary<string, DTInterfaceInfo > dtdlInterfaces = new Dictionary<string, DTInterfaceInfo>();

        public DTDLRepository(DigitalTwinsClient adtClient)
        {
            this.adtClient = adtClient;
        }

        public async Task< PropertyKind> GetPropertyKind(string modelId, string propertyName)
        {
            if (!dtdlInterfaces.ContainsKey(modelId))
            {
                var model = await adtClient.GetModelAsync(modelId);
                if (model.GetRawResponse().Status == 200)
                {
                    var modelData = model.Value;
                    var modelJson = new List<string>();
                    modelJson.Add(modelData.DtdlModel);
                    var parser = new ModelParser();
                    var parsedModel = await parser.ParseAsync(modelJson);
                    DTInterfaceInfo ifDef = null;
                    foreach (var definedKey in parsedModel.Keys)
                    {
                        var definedContent = parsedModel[definedKey];
                        if (definedContent.EntityKind == DTEntityKind.Interface)
                        {
                            ifDef = (DTInterfaceInfo)definedContent;
                            break;
                        }
                    }
                    if (ifDef != null)
                    {
                        dtdlInterfaces.Add(modelId, ifDef);
                    }
                }
            }
            var targetModel = dtdlInterfaces[modelId];
            PropertyKind result = PropertyKind.Unknown;
            if (targetModel.Contents.ContainsKey(propertyName))
            {
                var targetContent = targetModel.Contents[propertyName];
                switch (targetContent.EntityKind)
                {
                    case DTEntityKind.Property:
                        result = PropertyKind.Property;
                        break;
                    case DTEntityKind.Telemetry:
                        result = PropertyKind.Telemetry;
                            break;
                    case DTEntityKind.Command:
                        result = PropertyKind.Command;
                        break;
                }
            }

            return result;
        }

        public enum PropertyKind
        {
            Unknown,
            Telemetry,
            Property,
            Command
        }
    }
}
