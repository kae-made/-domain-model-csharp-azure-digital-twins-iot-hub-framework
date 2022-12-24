# Domain Model C# framework for Azure Digital Twins and Azure IoT Hub
1. clone this repository
2. Generate Domain Model C# code library by https://github.com/kae-made/domainmodel-code-generator-csharp into cloned folder.
3. Remove project reference of Kae.DomainModel.CSharp.Utility.Application.WebAPIAppDomainModelViewerForADT
4. Add generated Domain Model C# code library as project reference to Kae.DomainModel.CSharp.Utility.Application.WebAPIAppDomainModelViewerForADT
5. Deploy following Azure Function and Web App projects
 - Kae.DomainModel.CSharp.Utility.Application.AzureDigitalTwinsFunction
 - Kae.DomainMode.Csharp.AzureDigitalTwins.AzureIoTHubBinder
 - Kae.DomainModel.Csharp.AzureDigitalTwins.Timer
6. Configure connection settings for Azure Digital Twins and Azure IoT Hub
