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

namespace ActionLogicGenerationTest
{
    public partial class DomainClassHBase : DomainClassH
    {
        protected static readonly string className = "H";

        public string DomainName { get { return CIMActionLogicGenerationTestLib.DomainName; }}
        public string ClassName { get { return className; } }

        InstanceRepository instanceRepository;
        protected Logger logger;


        public string GetIdForExternalStorage() {  return $"H_ID={attr_H_ID}"; }

        public static DomainClassHBase CreateInstance(InstanceRepository instanceRepository, Logger logger=null, IList<ChangedState> changedStates=null, bool synchronousMode = false)
        {
            var newInstance = new DomainClassHBase(instanceRepository, logger, synchronousMode);
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:H(H_ID={newInstance.Attr_H_ID}):create");

            instanceRepository.Add(newInstance);

            if (changedStates !=null) changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Create, Target = newInstance, ChangedProperties = null });

            return newInstance;
        }

        public DomainClassHBase(InstanceRepository instanceRepository, Logger logger, bool synchronousMode)
        {
            this.instanceRepository = instanceRepository;
            this.logger = logger;
            attr_H_ID = Guid.NewGuid().ToString();
            stateof_H_ID = true;
        }
        protected string attr_H_ID;
        protected bool stateof_H_ID = false;

        public string Attr_H_ID { get { return attr_H_ID; } set { attr_H_ID = value; stateof_H_ID = true; } }


        // This method can be used as compare predicattion when calling InstanceRepository's SelectInstances method. 
        public static bool Compare(DomainClassH instance, IDictionary<string, object> conditionPropertyValues)
        {
            bool result = true;
            foreach (var propertyName in conditionPropertyValues.Keys)
            {
                switch (propertyName)
                {
                    case "H_ID":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_H_ID)
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

        public IEnumerable<DomainClassI> LinkedR8OneLeft()
        {
            var result = new List<DomainClassI>();
            var candidates = instanceRepository.GetDomainInstances("I").Where(inst=>(this.Attr_H_ID==((DomainClassI)inst).Attr_rightH_ID));
            if (instanceRepository.ExternalStorageAdaptor != null) candidates = instanceRepository.ExternalStorageAdaptor.CheckTraverseStatus(DomainName, this, "I", "R8_Left", candidates, () => { return DomainClassIBase.CreateInstance(instanceRepository, logger); }, "many").Result;
            foreach (var c in candidates)
            {
                ((DomainClassI)c).LinkedR8OtherRight();
                result.Add((DomainClassI)c);
            }
            return result;
        }



        
        public bool Validate()
        {
            bool isValid = true;
            if (this.LinkedR8OneLeft().Count() == 0)
            {
                isValid = false;
            }

            return isValid;
        }

        public void DeleteInstance(IList<ChangedState> changedStates=null)
        {
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:H(H_ID={this.Attr_H_ID}):delete");

            changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Delete, Target = this, ChangedProperties = null });

            instanceRepository.Delete(this);
        }

        // methods for storage
        public void Restore(IDictionary<string, object> propertyValues)
        {
            if (propertyValues.ContainsKey("H_ID"))
            {
// should adopt timer setting
                attr_H_ID = (string)propertyValues["H_ID"];
            }
            stateof_H_ID = false;
        }
        
        public IDictionary<string, object> ChangedProperties()
        {
            var results = new Dictionary<string, object>();
            if (stateof_H_ID)
            {
                results.Add("H_ID", attr_H_ID);
                stateof_H_ID = false;
            }

            return results;
        }

        public string GetIdentities()
        {
            string identities = $"H_ID={this.Attr_H_ID}";

            return identities;
        }
        
        public IDictionary<string, object> GetProperties(bool onlyIdentity)
        {
            var results = new Dictionary<string, object>();

            if (!onlyIdentity) results.Add("H_ID", attr_H_ID);

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
