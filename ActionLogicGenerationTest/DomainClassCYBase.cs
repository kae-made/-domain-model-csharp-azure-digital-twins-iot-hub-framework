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
    public partial class DomainClassCYBase : DomainClassCY
    {
        protected static readonly string className = "CY";

        public string DomainName { get { return CIMActionLogicGenerationTestLib.DomainName; }}
        public string ClassName { get { return className; } }

        InstanceRepository instanceRepository;
        protected Logger logger;


        public string GetIdForExternalStorage() {  return $"S_ID={attr_S_ID}"; }

        public static DomainClassCYBase CreateInstance(InstanceRepository instanceRepository, Logger logger=null, IList<ChangedState> changedStates=null, bool synchronousMode = false)
        {
            var newInstance = new DomainClassCYBase(instanceRepository, logger, synchronousMode);
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:CY(S_ID={newInstance.Attr_S_ID}):create");

            instanceRepository.Add(newInstance);

            if (changedStates !=null) changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Create, Target = newInstance, ChangedProperties = null });

            return newInstance;
        }

        public DomainClassCYBase(InstanceRepository instanceRepository, Logger logger, bool synchronousMode)
        {
            this.instanceRepository = instanceRepository;
            this.logger = logger;
        }
        protected string attr_S_ID;
        protected bool stateof_S_ID = false;

        protected int attr_Price;
        protected bool stateof_Price = false;

        public string Attr_S_ID { get { return attr_S_ID; } }
        public int Attr_Price { get { return attr_Price; } set { attr_Price = value; stateof_Price = true; } }


        // This method can be used as compare predicattion when calling InstanceRepository's SelectInstances method. 
        public static bool Compare(DomainClassCY instance, IDictionary<string, object> conditionPropertyValues)
        {
            bool result = true;
            foreach (var propertyName in conditionPropertyValues.Keys)
            {
                switch (propertyName)
                {
                    case "S_ID":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_S_ID)
                        {
                            result = false;
                        }
                        break;
                    case "Price":
                        if ((int)conditionPropertyValues[propertyName] != instance.Attr_Price)
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
        protected LinkedInstance relR6S;
        public DomainClassS GetSuperClassR6()
        {
            if (relR6S == null)
            {
                var candidates = instanceRepository.GetDomainInstances("S").Where(inst => (this.Attr_S_ID==((DomainClassS)inst).Attr_S_ID));
                if (candidates.Count() == 0)
                {
                   if (instanceRepository.ExternalStorageAdaptor != null) candidates = instanceRepository.ExternalStorageAdaptor.CheckTraverseStatus(DomainName, this, "S", "R6_CY", candidates, () => { return DomainClassSBase.CreateInstance(instanceRepository, logger); }, "any").Result;
                }
                relR6S = new LinkedInstance() { Source = this, Destination = candidates.FirstOrDefault(), RelationshipID = "R6", Phrase = null };
            }
            return relR6S.GetDestination<DomainClassS>();
        }

        public bool LinkR6(DomainClassS instance, IList<ChangedState> changedStates=null)
        {
            bool result = false;
            if (relR6S == null)
            {
                this.attr_S_ID = instance.Attr_S_ID;
                this.stateof_S_ID = true;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:CY(S_ID={this.Attr_S_ID}):link[S(S_ID={instance.Attr_S_ID})]");

                result = (GetSuperClassR6()!=null);
                if (result)
                {
                    if (changedStates != null) changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Create, Target = relR6S });
                }
            }
            return result;
        }
        
        public bool UnlinkR6(DomainClassS instance, IList<ChangedState> changedStates=null)
        {
            bool result = false;
            if (relR6S != null && ( this.Attr_S_ID==instance.Attr_S_ID ))
            {
                if (changedStates != null) changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Delete, Target = relR6S });
        
                this.attr_S_ID = null;
                this.stateof_S_ID = true;
                relR6S = null;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:CY(S_ID={this.Attr_S_ID}):unlink[S(S_ID={instance.Attr_S_ID})]");

                result = true;
            }
            return result;
        }



        
        public bool Validate()
        {
            bool isValid = true;
            if (relR6S == null)
            {
                isValid = false;
            }
            return isValid;
        }

        public void DeleteInstance(IList<ChangedState> changedStates=null)
        {
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:CY(S_ID={this.Attr_S_ID}):delete");

            changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Delete, Target = this, ChangedProperties = null });

            instanceRepository.Delete(this);
        }

        // methods for storage
        public void Restore(IDictionary<string, object> propertyValues)
        {
            if (propertyValues.ContainsKey("S_ID"))
            {
// should adopt timer setting
                attr_S_ID = (string)propertyValues["S_ID"];
            }
            stateof_S_ID = false;
            if (propertyValues.ContainsKey("Price"))
            {
// should adopt timer setting
                attr_Price = (int)propertyValues["Price"];
            }
            stateof_Price = false;
        }
        
        public IDictionary<string, object> ChangedProperties()
        {
            var results = new Dictionary<string, object>();
            if (stateof_S_ID)
            {
                results.Add("S_ID", attr_S_ID);
                stateof_S_ID = false;
            }
            if (stateof_Price)
            {
                results.Add("Price", attr_Price);
                stateof_Price = false;
            }

            return results;
        }

        public string GetIdentities()
        {
            string identities = $"S_ID={this.Attr_S_ID}";

            return identities;
        }
        
        public IDictionary<string, object> GetProperties(bool onlyIdentity)
        {
            var results = new Dictionary<string, object>();

            if (!onlyIdentity) results.Add("S_ID", attr_S_ID);
            if (!onlyIdentity) results.Add("Price", attr_Price);

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
