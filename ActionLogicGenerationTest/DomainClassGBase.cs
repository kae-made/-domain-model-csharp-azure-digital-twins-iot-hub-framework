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
    public partial class DomainClassGBase : DomainClassG
    {
        protected static readonly string className = "G";

        public string DomainName { get { return CIMActionLogicGenerationTestLib.DomainName; }}
        public string ClassName { get { return className; } }

        InstanceRepository instanceRepository;
        protected Logger logger;


        public string GetIdForExternalStorage() {  return $"G_ID={attr_G_ID}"; }

        public static DomainClassGBase CreateInstance(InstanceRepository instanceRepository, Logger logger=null, IList<ChangedState> changedStates=null, bool synchronousMode = false)
        {
            var newInstance = new DomainClassGBase(instanceRepository, logger, synchronousMode);
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:G(G_ID={newInstance.Attr_G_ID}):create");

            instanceRepository.Add(newInstance);

            if (changedStates !=null) changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Create, Target = newInstance, ChangedProperties = null });

            return newInstance;
        }

        public DomainClassGBase(InstanceRepository instanceRepository, Logger logger, bool synchronousMode)
        {
            this.instanceRepository = instanceRepository;
            this.logger = logger;
            attr_G_ID = Guid.NewGuid().ToString();
            stateof_G_ID = true;
        }
        protected string attr_G_ID;
        protected bool stateof_G_ID = false;

        public string Attr_G_ID { get { return attr_G_ID; } set { attr_G_ID = value; stateof_G_ID = true; } }


        // This method can be used as compare predicattion when calling InstanceRepository's SelectInstances method. 
        public static bool Compare(DomainClassG instance, IDictionary<string, object> conditionPropertyValues)
        {
            bool result = true;
            foreach (var propertyName in conditionPropertyValues.Keys)
            {
                switch (propertyName)
                {
                    case "G_ID":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_G_ID)
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

        public IEnumerable<DomainClassI> LinkedR8OtherRight()
        {
            var result = new List<DomainClassI>();
            var candidates = instanceRepository.GetDomainInstances("I").Where(inst=>(this.Attr_G_ID==((DomainClassI)inst).Attr_leftG_ID));
            if (instanceRepository.ExternalStorageAdaptor != null) candidates = instanceRepository.ExternalStorageAdaptor.CheckTraverseStatus(DomainName, this, "I", "R8_Right", candidates, () => { return DomainClassIBase.CreateInstance(instanceRepository, logger); }, "many").Result;
            foreach (var c in candidates)
            {
                ((DomainClassI)c).LinkedR8OneLeft();
                result.Add((DomainClassI)c);
            }
            return result;
        }



        
        public bool Validate()
        {
            bool isValid = true;
            if (this.LinkedR8OtherRight().Count() == 0)
            {
                isValid = false;
            }

            return isValid;
        }

        public void DeleteInstance(IList<ChangedState> changedStates=null)
        {
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:G(G_ID={this.Attr_G_ID}):delete");

            changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Delete, Target = this, ChangedProperties = null });

            instanceRepository.Delete(this);
        }

        // methods for storage
        public void Restore(IDictionary<string, object> propertyValues)
        {
            if (propertyValues.ContainsKey("G_ID"))
            {
// should adopt timer setting
                attr_G_ID = (string)propertyValues["G_ID"];
            }
            stateof_G_ID = false;
        }
        
        public IDictionary<string, object> ChangedProperties()
        {
            var results = new Dictionary<string, object>();
            if (stateof_G_ID)
            {
                results.Add("G_ID", attr_G_ID);
                stateof_G_ID = false;
            }

            return results;
        }

        public string GetIdentities()
        {
            string identities = $"G_ID={this.Attr_G_ID}";

            return identities;
        }
        
        public IDictionary<string, object> GetProperties(bool onlyIdentity)
        {
            var results = new Dictionary<string, object>();

            if (!onlyIdentity) results.Add("G_ID", attr_G_ID);

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
