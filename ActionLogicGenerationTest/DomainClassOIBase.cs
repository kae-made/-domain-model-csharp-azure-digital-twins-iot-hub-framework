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
    public partial class DomainClassOIBase : DomainClassOI
    {
        protected static readonly string className = "OI";

        public string DomainName { get { return CIMActionLogicGenerationTestLib.DomainName; }}
        public string ClassName { get { return className; } }

        InstanceRepository instanceRepository;
        protected Logger logger;


        public string GetIdForExternalStorage() {  return $"prevI_ID={attr_prevI_ID};nextG_ID={attr_nextG_ID};nextH_ID={attr_nextH_ID}"; }

        public static DomainClassOIBase CreateInstance(InstanceRepository instanceRepository, Logger logger=null, IList<ChangedState> changedStates=null, bool synchronousMode = false)
        {
            var newInstance = new DomainClassOIBase(instanceRepository, logger, synchronousMode);
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:OI(prevI_ID={newInstance.Attr_prevI_ID},nextG_ID={newInstance.Attr_nextG_ID},nextH_ID={newInstance.Attr_nextH_ID}):create");

            instanceRepository.Add(newInstance);

            if (changedStates !=null) changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Create, Target = newInstance, ChangedProperties = null });

            return newInstance;
        }

        public DomainClassOIBase(InstanceRepository instanceRepository, Logger logger, bool synchronousMode)
        {
            this.instanceRepository = instanceRepository;
            this.logger = logger;
        }
        protected string attr_prevI_ID;
        protected bool stateof_prevI_ID = false;

        protected string attr_nextG_ID;
        protected bool stateof_nextG_ID = false;

        protected string attr_nextH_ID;
        protected bool stateof_nextH_ID = false;

        protected int attr_Order;
        protected bool stateof_Order = false;

        public string Attr_prevI_ID { get { return attr_prevI_ID; } }
        public string Attr_nextG_ID { get { return attr_nextG_ID; } }
        public string Attr_nextH_ID { get { return attr_nextH_ID; } }
        public int Attr_Order { get { return attr_Order; } set { attr_Order = value; stateof_Order = true; } }


        // This method can be used as compare predicattion when calling InstanceRepository's SelectInstances method. 
        public static bool Compare(DomainClassOI instance, IDictionary<string, object> conditionPropertyValues)
        {
            bool result = true;
            foreach (var propertyName in conditionPropertyValues.Keys)
            {
                switch (propertyName)
                {
                    case "prevI_ID":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_prevI_ID)
                        {
                            result = false;
                        }
                        break;
                    case "nextG_ID":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_nextG_ID)
                        {
                            result = false;
                        }
                        break;
                    case "nextH_ID":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_nextH_ID)
                        {
                            result = false;
                        }
                        break;
                    case "Order":
                        if ((int)conditionPropertyValues[propertyName] != instance.Attr_Order)
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
        protected LinkedInstance relR9INext;
        // private DomainClassI relR9INext;
        protected LinkedInstance relR9IPrev;
        // private DomainClassI relR9IPrev;
        public bool LinkR9(DomainClassI oneInstanceNext, DomainClassI otherInstancePrev, IList<ChangedState> changedStates=null)
        {
            bool result = false;
            if (relR9INext == null && relR9IPrev == null)
            {
                this.attr_prevI_ID = oneInstanceNext.Attr_I_ID;
                this.stateof_prevI_ID = true;
                this.attr_nextG_ID = otherInstancePrev.Attr_leftG_ID;
                this.stateof_nextG_ID = true;
                this.attr_nextH_ID = otherInstancePrev.Attr_rightH_ID;
                this.stateof_nextH_ID = true;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:OI(prevI_ID={this.Attr_prevI_ID},nextG_ID={this.Attr_nextG_ID},nextH_ID={this.Attr_nextH_ID}):link[One(I(I_ID={oneInstanceNext.Attr_I_ID})),Other(I(I_ID={otherInstancePrev.Attr_I_ID}))]");

                result = (LinkedR9OneNext()!=null) && (LinkedR9OtherPrev()!=null);
                if (result)
                {
                    if (changedStates != null)
                    {
                        changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Create, Target = relR9INext });
                        changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Create, Target = relR9IPrev });
                    }
                }
            }
            return result;
        }
        
        public bool UnlinkR9(DomainClassI oneInstanceNext, DomainClassI otherInstancePrev, IList<ChangedState> changedStates=null)
        {
            bool result = false;
            if (relR9INext != null && relR9IPrev != null)
            {
                if ((this.Attr_prevI_ID==oneInstanceNext.Attr_I_ID) && (this.Attr_nextG_ID==otherInstancePrev.Attr_leftG_ID && this.Attr_nextH_ID==otherInstancePrev.Attr_rightH_ID))
                {
                    if (changedStates != null)
                    {
                        changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Delete, Target = relR9INext });
                        changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Delete, Target = relR9IPrev });
                    }
        
                    this.attr_prevI_ID = null;
                    this.stateof_prevI_ID = true;
                    this.attr_nextG_ID = null;
                    this.stateof_nextG_ID = true;
                    this.attr_nextH_ID = null;
                    this.stateof_nextH_ID = true;
                    relR9INext = null;
                    relR9IPrev = null;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:OI(prevI_ID={this.Attr_prevI_ID},nextG_ID={this.Attr_nextG_ID},nextH_ID={this.Attr_nextH_ID}):unlink[I(I_ID={oneInstanceNext.Attr_I_ID})]");

                    result = true;
                }
            }
            return result;
        }
        
        public DomainClassI LinkedR9OneNext()
        {
            if (relR9INext == null)
            {
                var candidates = instanceRepository.GetDomainInstances("I").Where(inst=>(this.Attr_prevI_ID==((DomainClassI)inst).Attr_I_ID));
                if (candidates.Count() == 0)
                {
                   if (instanceRepository.ExternalStorageAdaptor != null) candidates = instanceRepository.ExternalStorageAdaptor.CheckTraverseStatus(DomainName, this, "I", "R9_Next", candidates, () => { return DomainClassIBase.CreateInstance(instanceRepository, logger); }, "any").Result;
                }
                relR9INext = new LinkedInstance() { Source = this, Destination = candidates.FirstOrDefault(), RelationshipID = "R9", Phrase = "Next" };
                // (DomainClassI)candidates.FirstOrDefault();
            }
            return relR9INext.GetDestination<DomainClassI>();
        }
        
        public DomainClassI LinkedR9OtherPrev()
        {
            if (relR9IPrev == null)
            {
                var candidates = instanceRepository.GetDomainInstances("I").Where(inst=>(this.Attr_nextG_ID==((DomainClassI)inst).Attr_leftG_ID && this.Attr_nextH_ID==((DomainClassI)inst).Attr_rightH_ID));
                if (candidates.Count() == 0)
                {
                   if (instanceRepository.ExternalStorageAdaptor != null) candidates = instanceRepository.ExternalStorageAdaptor.CheckTraverseStatus(DomainName, this, "I", "R9_Prev", candidates, () => { return DomainClassIBase.CreateInstance(instanceRepository, logger); }, "any").Result;
                }
                relR9IPrev = new LinkedInstance() { Source = this, Destination = candidates.FirstOrDefault(), RelationshipID = "R9", Phrase = "Prev" };
                // (DomainClassI)candidates.FirstOrDefault();
            }
            return relR9IPrev.GetDestination<DomainClassI>();
        }



        
        public bool Validate()
        {
            bool isValid = true;
            if (relR9INext == null)
            {
                isValid = false;
            }
            if (relR9IPrev == null)
            {
                isValid = false;
            }
            return isValid;
        }

        public void DeleteInstance(IList<ChangedState> changedStates=null)
        {
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:OI(prevI_ID={this.Attr_prevI_ID},nextG_ID={this.Attr_nextG_ID},nextH_ID={this.Attr_nextH_ID}):delete");

            changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Delete, Target = this, ChangedProperties = null });

            instanceRepository.Delete(this);
        }

        // methods for storage
        public void Restore(IDictionary<string, object> propertyValues)
        {
            if (propertyValues.ContainsKey("prevI_ID"))
            {
// should adopt timer setting
                attr_prevI_ID = (string)propertyValues["prevI_ID"];
            }
            stateof_prevI_ID = false;
            if (propertyValues.ContainsKey("nextG_ID"))
            {
// should adopt timer setting
                attr_nextG_ID = (string)propertyValues["nextG_ID"];
            }
            stateof_nextG_ID = false;
            if (propertyValues.ContainsKey("nextH_ID"))
            {
// should adopt timer setting
                attr_nextH_ID = (string)propertyValues["nextH_ID"];
            }
            stateof_nextH_ID = false;
            if (propertyValues.ContainsKey("Order"))
            {
// should adopt timer setting
                attr_Order = (int)propertyValues["Order"];
            }
            stateof_Order = false;
        }
        
        public IDictionary<string, object> ChangedProperties()
        {
            var results = new Dictionary<string, object>();
            if (stateof_prevI_ID)
            {
                results.Add("prevI_ID", attr_prevI_ID);
                stateof_prevI_ID = false;
            }
            if (stateof_nextG_ID)
            {
                results.Add("nextG_ID", attr_nextG_ID);
                stateof_nextG_ID = false;
            }
            if (stateof_nextH_ID)
            {
                results.Add("nextH_ID", attr_nextH_ID);
                stateof_nextH_ID = false;
            }
            if (stateof_Order)
            {
                results.Add("Order", attr_Order);
                stateof_Order = false;
            }

            return results;
        }

        public string GetIdentities()
        {
            string identities = $"prevI_ID={this.Attr_prevI_ID},nextG_ID={this.Attr_nextG_ID},nextH_ID={this.Attr_nextH_ID}";

            return identities;
        }
        
        public IDictionary<string, object> GetProperties(bool onlyIdentity)
        {
            var results = new Dictionary<string, object>();

            if (!onlyIdentity) results.Add("prevI_ID", attr_prevI_ID);
            if (!onlyIdentity) results.Add("nextG_ID", attr_nextG_ID);
            if (!onlyIdentity) results.Add("nextH_ID", attr_nextH_ID);
            if (!onlyIdentity) results.Add("Order", attr_Order);

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