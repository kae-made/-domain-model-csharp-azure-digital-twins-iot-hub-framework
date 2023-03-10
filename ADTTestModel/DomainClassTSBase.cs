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
    public partial class DomainClassTSBase : DomainClassTS
    {
        protected static readonly string className = "TS";

        public string DomainName { get { return CIMADTTestModelLib.DomainName; }}
        public string ClassName { get { return className; } }

        InstanceRepository instanceRepository;
        protected Logger logger;


        public string GetIdForExternalStorage() {  return $"TSId={attr_TSId}"; }

        public static DomainClassTSBase CreateInstance(InstanceRepository instanceRepository, Logger logger=null, IList<ChangedState> changedStates=null, bool synchronousMode = false)
        {
            var newInstance = new DomainClassTSBase(instanceRepository, logger, synchronousMode);
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:TS(TSId={newInstance.Attr_TSId}):create");

            instanceRepository.Add(newInstance);

            if (changedStates !=null) changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Create, Target = newInstance, ChangedProperties = null });

            return newInstance;
        }

        public DomainClassTSBase(InstanceRepository instanceRepository, Logger logger, bool synchronousMode)
        {
            this.instanceRepository = instanceRepository;
            this.logger = logger;
            attr_TSId = Guid.NewGuid().ToString();
            stateof_TSId = true;
        }
        protected string attr_TSId;
        protected bool stateof_TSId = false;

        public string Attr_TSId { get { return attr_TSId; } set { attr_TSId = value; stateof_TSId = true; } }


        // This method can be used as compare predicattion when calling InstanceRepository's SelectInstances method. 
        public static bool Compare(DomainClassTS instance, IDictionary<string, object> conditionPropertyValues)
        {
            bool result = true;
            foreach (var propertyName in conditionPropertyValues.Keys)
            {
                switch (propertyName)
                {
                    case "TSId":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_TSId)
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

        public SubClassR4 GetSubR4()
        {
            SubClassR4 result = null;
            var subClassKeys = new List<string>() { "SC1", "SC2" };
            foreach (var key in subClassKeys)
            {
                var candidates = instanceRepository.GetDomainInstances(key).Where(inst=>((this == ((SubClassR4)inst).GetSuperClassR4())));
                if (instanceRepository.ExternalStorageAdaptor != null)  candidates = instanceRepository.ExternalStorageAdaptor.CheckInstanceStatus(DomainName, key, candidates, () => { return "TSId = '{this.Attr_TSId}'"; }, () => { return SubClassR4Factory.CreateInstance(key, instanceRepository, logger); }, "any").Result;
                if (candidates.Count() > 0)
                {
                    result = (SubClassR4)candidates.FirstOrDefault();
                    result.GetSuperClassR4();
                    break;
                }
            }
            return result;
        }


        public DomainClassSC1 LinkedR4SC1()
        {
            return (DomainClassSC1)GetSubR4();
        }


        public DomainClassSC2 LinkedR4SC2()
        {
            return (DomainClassSC2)GetSubR4();
        }



        
        public bool Validate()
        {
            bool isValid = true;
            if (this.GetSubR4() == null)
            {
                isValid = false;
            }
            return isValid;
        }

        public void DeleteInstance(IList<ChangedState> changedStates=null)
        {
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:TS(TSId={this.Attr_TSId}):delete");

            changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Delete, Target = this, ChangedProperties = null });

            instanceRepository.Delete(this);
        }

        // methods for storage
        public void Restore(IDictionary<string, object> propertyValues)
        {
            if (propertyValues.ContainsKey("TSId"))
            {
// should adopt timer setting
                attr_TSId = (string)propertyValues["TSId"];
            }
            stateof_TSId = false;
        }
        
        public IDictionary<string, object> ChangedProperties()
        {
            var results = new Dictionary<string, object>();
            if (stateof_TSId)
            {
                results.Add("TSId", attr_TSId);
                stateof_TSId = false;
            }

            return results;
        }

        public string GetIdentities()
        {
            string identities = $"TSId={this.Attr_TSId}";

            return identities;
        }
        
        public IDictionary<string, object> GetProperties(bool onlyIdentity)
        {
            var results = new Dictionary<string, object>();

            if (!onlyIdentity) results.Add("TSId", attr_TSId);

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
