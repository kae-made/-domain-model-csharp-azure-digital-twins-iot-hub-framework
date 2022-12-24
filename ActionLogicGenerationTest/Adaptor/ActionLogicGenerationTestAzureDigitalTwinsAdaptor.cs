// ------------------------------------------------------------------------------
// <auto-generated>
//     This file is generated by tool.
//     Runtime Version : 1.0.0
//  
// </auto-generated>
// ------------------------------------------------------------------------------
using Azure.Core;
using Kae.DomainModel.Csharp.Framework;
using Kae.DomainModel.Csharp.Framework.Adaptor;
using Kae.DomainModel.Csharp.Framework.Adaptor.ExternalStorage;
using Kae.DomainModel.Csharp.Framework.Adaptor.ExternalStorage.AzureDigitalTwins;
using Kae.Utility.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionLogicGenerationTest.Adaptor
{
    public class ActionLogicGenerationTestAzureDigitalTwinsAdaptor : AzureDigitalTwinsAdaptor
    {

        Dictionary<string, string> cClassToTwinModel = new Dictionary<string, string>()
        {
            { "A", "dtmi:com:kae_made:ActionLogicGenerationTest:A;1" },
            { "B", "dtmi:com:kae_made:ActionLogicGenerationTest:B;1" },
            { "C", "dtmi:com:kae_made:ActionLogicGenerationTest:C;1" },
            { "CX", "dtmi:com:kae_made:ActionLogicGenerationTest:CX;1" },
            { "S", "dtmi:com:kae_made:ActionLogicGenerationTest:S;1" },
            { "CY", "dtmi:com:kae_made:ActionLogicGenerationTest:CY;1" },
            { "D", "dtmi:com:kae_made:ActionLogicGenerationTest:D;1" },
            { "G", "dtmi:com:kae_made:ActionLogicGenerationTest:G;1" },
            { "H", "dtmi:com:kae_made:ActionLogicGenerationTest:H;1" },
            { "I", "dtmi:com:kae_made:ActionLogicGenerationTest:I;1" },
            { "OI", "dtmi:com:kae_made:ActionLogicGenerationTest:OI;1" },
            { "R", "dtmi:com:kae_made:ActionLogicGenerationTest:R;1" }
        };

        Dictionary<string, DTDLRelationshipDef> cRelationshipToTwinRelationships = new Dictionary<string, DTDLRelationshipDef>()
        {
            { "R1", new DTDLRelationshipDef() { Id="dtmi:com:kae_made:ActionLogicGenerationTest:R1_A;1", Name="R1_A", SourceTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:B;1", TargetTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:A;1", FormClassKeyLetter="B", PartClassKeyLetter="A" } },
            { "R2", new DTDLRelationshipDef() { Id="dtmi:com:kae_made:ActionLogicGenerationTest:R2_B;1", Name="R2_B", SourceTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:C;1", TargetTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:B;1", FormClassKeyLetter="C", PartClassKeyLetter="B" } },
            { "R3", new DTDLRelationshipDef() { Id="dtmi:com:kae_made:ActionLogicGenerationTest:R3_C;1", Name="R3_C", SourceTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:C;1", TargetTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:C;1", FormClassKeyLetter="C", PartClassKeyLetter="C" } },
            { "R4", new DTDLRelationshipDef() { Id="dtmi:com:kae_made:ActionLogicGenerationTest:R4_A;1", Name="R4_A", SourceTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:D;1", TargetTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:A;1", FormClassKeyLetter="D", PartClassKeyLetter="A" } },
            { "R5_", new DTDLRelationshipDef() { Id="dtmi:com:kae_made:ActionLogicGenerationTest:R5__D;1", Name="R5__D", SourceTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:R;1", TargetTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:D;1", FormClassKeyLetter="R", PartClassKeyLetter="D" } },
            { "R5_", new DTDLRelationshipDef() { Id="dtmi:com:kae_made:ActionLogicGenerationTest:R5__S;1", Name="R5__S", SourceTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:R;1", TargetTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:S;1", FormClassKeyLetter="R", PartClassKeyLetter="S" } },
            { "R6_CX", new DTDLRelationshipDef() { Id="dtmi:com:kae_made:ActionLogicGenerationTest:R6FromCX;1", Name="R6FromCX", SourceTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:CX;1", TargetTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:S;1", FormClassKeyLetter="CX", PartClassKeyLetter="S" } },
            { "R6_CY", new DTDLRelationshipDef() { Id="dtmi:com:kae_made:ActionLogicGenerationTest:R6FromCY;1", Name="R6FromCY", SourceTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:CY;1", TargetTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:S;1", FormClassKeyLetter="CY", PartClassKeyLetter="S" } },
            { "R7", new DTDLRelationshipDef() { Id="dtmi:com:kae_made:ActionLogicGenerationTest:R7_C;1", Name="R7_C", SourceTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:CX;1", TargetTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:C;1", FormClassKeyLetter="CX", PartClassKeyLetter="C" } },
            { "R8_Left", new DTDLRelationshipDef() { Id="dtmi:com:kae_made:ActionLogicGenerationTest:R8_Left_G;1", Name="R8_Left_G", SourceTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:I;1", TargetTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:G;1", FormClassKeyLetter="I", PartClassKeyLetter="G" } },
            { "R8_Right", new DTDLRelationshipDef() { Id="dtmi:com:kae_made:ActionLogicGenerationTest:R8_Right_H;1", Name="R8_Right_H", SourceTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:I;1", TargetTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:H;1", FormClassKeyLetter="I", PartClassKeyLetter="H" } },
            { "R9_Next", new DTDLRelationshipDef() { Id="dtmi:com:kae_made:ActionLogicGenerationTest:R9_Next_I;1", Name="R9_Next_I", SourceTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:OI;1", TargetTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:I;1", FormClassKeyLetter="OI", PartClassKeyLetter="I" } },
            { "R9_Prev", new DTDLRelationshipDef() { Id="dtmi:com:kae_made:ActionLogicGenerationTest:R9_Prev_I;1", Name="R9_Prev_I", SourceTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:OI;1", TargetTwinModelId="dtmi:com:kae_made:ActionLogicGenerationTest:I;1", FormClassKeyLetter="OI", PartClassKeyLetter="I" } }
        };

        public ActionLogicGenerationTestAzureDigitalTwinsAdaptor(string adtInstanceUrl, TokenCredential credential, InstanceRepository repository, Logger logger) : base(adtInstanceUrl, credential, repository, logger)
        {
            ;
        }

        public override DTDLRelationshipDef GetDTDLRelationshipDef(string domainName, string relationshipName)
        {
            return cRelationshipToTwinRelationships[relationshipName];
        }

        public override string GetDTDLTwinModelId(string domainName, string classKeyLetter)
        {
            return cClassToTwinModel[classKeyLetter];
        }

    }
}
