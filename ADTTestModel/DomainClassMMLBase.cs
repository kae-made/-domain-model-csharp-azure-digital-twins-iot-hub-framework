// ------------------------------------------------------------------------------
// <auto-generated>
//     This file is generated by tool.
//     Runtime Version : 1.0.0
//  
//     Updates this file cause incorrect behavior 
//     and will be lost when the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Kae.StateMachine;
using Kae.Utility.Logging;
using Kae.DomainModel.Csharp.Framework;
using Kae.DomainModel.Csharp.Framework.Adaptor.ExternalStorage;

namespace ADTTestModel
{
    public partial class DomainClassMMLBase : DomainClassMML
    {
        protected static readonly string className = "MML";

        public string DomainName { get { return CIMADTTestModelLib.DomainName; }}
        public string ClassName { get { return className; } }

        InstanceRepository instanceRepository;
        protected Logger logger;


        public string GetIdForExternalStorage() {  return $"MMLId={attr_MMLId}"; }

        public static DomainClassMMLBase CreateInstance(InstanceRepository instanceRepository, Logger logger=null, IList<ChangedState> changedStates=null, bool synchronousMode = false)
        {
            var newInstance = new DomainClassMMLBase(instanceRepository, logger, synchronousMode);
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:MML(MMLId={newInstance.Attr_MMLId}):create");

            instanceRepository.Add(newInstance);

            if (changedStates !=null) changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Create, Target = newInstance, ChangedProperties = null });

            return newInstance;
        }

        public DomainClassMMLBase(InstanceRepository instanceRepository, Logger logger, bool synchronousMode)
        {
            this.instanceRepository = instanceRepository;
            this.logger = logger;
            attr_MMLId = Guid.NewGuid().ToString();
            stateof_MMLId = true;
        }
        protected string attr_MMLId;
        protected bool stateof_MMLId = false;

        protected string attr_MiddleEntityId;
        protected bool stateof_MiddleEntityId = false;

        protected string attr_LiefDeviceId;
        protected bool stateof_LiefDeviceId = false;

        public string Attr_MMLId { get { return attr_MMLId; } set { attr_MMLId = value; stateof_MMLId = true; } }
        public string Attr_MiddleEntityId { get { return attr_MiddleEntityId; } }
        public string Attr_LiefDeviceId { get { return attr_LiefDeviceId; } }


        // This method can be used as compare predicattion when calling InstanceRepository's SelectInstances method. 
        public static bool Compare(DomainClassMML instance, IDictionary<string, object> conditionPropertyValues)
        {
            bool result = true;
            foreach (var propertyName in conditionPropertyValues.Keys)
            {
                switch (propertyName)
                {
                    case "MMLId":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_MMLId)
                        {
                            result = false;
                        }
                        break;
                    case "MiddleEntityId":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_MiddleEntityId)
                        {
                            result = false;
                        }
                        break;
                    case "LiefDeviceId":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_LiefDeviceId)
                        {
                            result = false;
                        }
                        break;
                }
                if (result== false)
                {
                    break;
                }
            }
            return result;
        }
        protected LinkedInstance relR5MEMiddle;
        // private DomainClassME relR5MEMiddle;
        protected LinkedInstance relR5LDLief;
        // private DomainClassLD relR5LDLief;
        public bool LinkR5(DomainClassME oneInstanceMiddle, DomainClassLD otherInstanceLief, IList<ChangedState> changedStates=null)
        {
            bool result = false;
            if (relR5MEMiddle == null && relR5LDLief == null)
            {
                this.attr_MiddleEntityId = oneInstanceMiddle.Attr_MiddleEntityId;
                this.stateof_MiddleEntityId = true;
                this.attr_LiefDeviceId = otherInstanceLief.Attr_LiefDeviceId;
                this.stateof_LiefDeviceId = true;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:MML(MMLId={this.Attr_MMLId}):link[One(ME(MiddleEntityId={oneInstanceMiddle.Attr_MiddleEntityId})),Other(LD(LiefDeviceId={otherInstanceLief.Attr_LiefDeviceId}))]");

                result = (LinkedR5OneMiddle()!=null) && (LinkedR5OtherLief()!=null);
                if (result)
                {
                    if (changedStates != null)
                    {
                        changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Create, Target = relR5MEMiddle });
                        changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Create, Target = relR5LDLief });
                    }
                }
            }
            return result;
        }
        
        public bool UnlinkR5(DomainClassME oneInstanceMiddle, DomainClassLD otherInstanceLief, IList<ChangedState> changedStates=null)
        {
            bool result = false;
            if (relR5MEMiddle != null && relR5LDLief != null)
            {
                if ((this.Attr_MiddleEntityId==oneInstanceMiddle.Attr_MiddleEntityId) && (this.Attr_LiefDeviceId==otherInstanceLief.Attr_LiefDeviceId))
                {
                    if (changedStates != null)
                    {
                        changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Delete, Target = relR5MEMiddle });
                        changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Delete, Target = relR5LDLief });
                    }
        
                    this.attr_MiddleEntityId = null;
                    this.stateof_MiddleEntityId = true;
                    this.attr_LiefDeviceId = null;
                    this.stateof_LiefDeviceId = true;
                    relR5MEMiddle = null;
                    relR5LDLief = null;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:MML(MMLId={this.Attr_MMLId}):unlink[ME(MiddleEntityId={oneInstanceMiddle.Attr_MiddleEntityId})]");

                    result = true;
                }
            }
            return result;
        }
        
        public DomainClassME LinkedR5OneMiddle()
        {
            if (relR5MEMiddle == null)
            {
                var candidates = instanceRepository.GetDomainInstances("ME").Where(inst=>(this.Attr_MiddleEntityId==((DomainClassME)inst).Attr_MiddleEntityId));
                if (candidates.Count() == 0)
                {
                   if (instanceRepository.ExternalStorageAdaptor != null) candidates = instanceRepository.ExternalStorageAdaptor.CheckTraverseStatus(DomainName, this, "ME", "R5_Middle", candidates, () => { return DomainClassMEBase.CreateInstance(instanceRepository, logger); }, "any").Result;
                }
                relR5MEMiddle = new LinkedInstance() { Source = this, Destination = candidates.FirstOrDefault(), RelationshipID = "R5", Phrase = "Middle" };
                // (DomainClassME)candidates.FirstOrDefault();
            }
            return relR5MEMiddle.GetDestination<DomainClassME>();
        }
        
        public DomainClassLD LinkedR5OtherLief()
        {
            if (relR5LDLief == null)
            {
                var candidates = instanceRepository.GetDomainInstances("LD").Where(inst=>(this.Attr_LiefDeviceId==((DomainClassLD)inst).Attr_LiefDeviceId));
                if (candidates.Count() == 0)
                {
                   if (instanceRepository.ExternalStorageAdaptor != null) candidates = instanceRepository.ExternalStorageAdaptor.CheckTraverseStatus(DomainName, this, "LD", "R5_Lief", candidates, () => { return DomainClassLDBase.CreateInstance(instanceRepository, logger); }, "any").Result;
                }
                relR5LDLief = new LinkedInstance() { Source = this, Destination = candidates.FirstOrDefault(), RelationshipID = "R5", Phrase = "Lief" };
                // (DomainClassLD)candidates.FirstOrDefault();
            }
            return relR5LDLief.GetDestination<DomainClassLD>();
        }



        
        public bool Validate()
        {
            bool isValid = true;
            if (relR5MEMiddle == null)
            {
                isValid = false;
            }
            if (relR5LDLief == null)
            {
                isValid = false;
            }
            return isValid;
        }

        public void DeleteInstance(IList<ChangedState> changedStates=null)
        {
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:MML(MMLId={this.Attr_MMLId}):delete");

            changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Delete, Target = this, ChangedProperties = null });

            instanceRepository.Delete(this);
        }

        // methods for storage
        public void Restore(IDictionary<string, object> propertyValues)
        {
            if (propertyValues.ContainsKey("MMLId"))
            {
// should adopt timer setting
                attr_MMLId = (string)propertyValues["MMLId"];
            }
            stateof_MMLId = false;
            if (propertyValues.ContainsKey("MiddleEntityId"))
            {
// should adopt timer setting
                attr_MiddleEntityId = (string)propertyValues["MiddleEntityId"];
            }
            stateof_MiddleEntityId = false;
            if (propertyValues.ContainsKey("LiefDeviceId"))
            {
// should adopt timer setting
                attr_LiefDeviceId = (string)propertyValues["LiefDeviceId"];
            }
            stateof_LiefDeviceId = false;
        }
        
        public IDictionary<string, object> ChangedProperties()
        {
            var results = new Dictionary<string, object>();
            if (stateof_MMLId)
            {
                results.Add("MMLId", attr_MMLId);
                stateof_MMLId = false;
            }
            if (stateof_MiddleEntityId)
            {
                results.Add("MiddleEntityId", attr_MiddleEntityId);
                stateof_MiddleEntityId = false;
            }
            if (stateof_LiefDeviceId)
            {
                results.Add("LiefDeviceId", attr_LiefDeviceId);
                stateof_LiefDeviceId = false;
            }

            return results;
        }

        public string GetIdentities()
        {
            string identities = $"MMLId={this.Attr_MMLId}";

            return identities;
        }
        
        public IDictionary<string, object> GetProperties(bool onlyIdentity)
        {
            var results = new Dictionary<string, object>();

            if (!onlyIdentity) results.Add("MMLId", attr_MMLId);
            if (!onlyIdentity) results.Add("MiddleEntityId", attr_MiddleEntityId);
            if (!onlyIdentity) results.Add("LiefDeviceId", attr_LiefDeviceId);

            return results;
        }

#if false
        List<ChangedState> changedStates = new List<ChangedState>();

        public IList<ChangedState> ChangedStates()
        {
            List<ChangedState> results = new List<ChangedState>();
            results.AddRange(changedStates);
            results.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Update, Target = this, ChangedProperties = ChangedProperties() });
            changedStates.Clear();

            return results;
        }
#endif
    }
}
