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
    public partial class DomainClassIBase : DomainClassI
    {
        protected static readonly string className = "I";

        public string DomainName { get { return CIMActionLogicGenerationTestLib.DomainName; }}
        public string ClassName { get { return className; } }

        InstanceRepository instanceRepository;
        protected Logger logger;


        public string GetIdForExternalStorage() {  return $"I_ID={attr_I_ID}"; }

        public static DomainClassIBase CreateInstance(InstanceRepository instanceRepository, Logger logger=null, IList<ChangedState> changedStates=null, bool synchronousMode = false)
        {
            var newInstance = new DomainClassIBase(instanceRepository, logger, synchronousMode);
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:I(I_ID={newInstance.Attr_I_ID}):create");

            instanceRepository.Add(newInstance);

            if (changedStates !=null) changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Create, Target = newInstance, ChangedProperties = null });

            return newInstance;
        }

        public DomainClassIBase(InstanceRepository instanceRepository, Logger logger, bool synchronousMode)
        {
            this.instanceRepository = instanceRepository;
            this.logger = logger;
            attr_I_ID = Guid.NewGuid().ToString();
            stateof_I_ID = true;
        }
        protected string attr_I_ID;
        protected bool stateof_I_ID = false;

        protected string attr_leftG_ID;
        protected bool stateof_leftG_ID = false;

        protected string attr_rightH_ID;
        protected bool stateof_rightH_ID = false;

        public string Attr_I_ID { get { return attr_I_ID; } set { attr_I_ID = value; stateof_I_ID = true; } }
        public string Attr_leftG_ID { get { return attr_leftG_ID; } }
        public string Attr_rightH_ID { get { return attr_rightH_ID; } }


        // This method can be used as compare predicattion when calling InstanceRepository's SelectInstances method. 
        public static bool Compare(DomainClassI instance, IDictionary<string, object> conditionPropertyValues)
        {
            bool result = true;
            foreach (var propertyName in conditionPropertyValues.Keys)
            {
                switch (propertyName)
                {
                    case "I_ID":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_I_ID)
                        {
                            result = false;
                        }
                        break;
                    case "leftG_ID":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_leftG_ID)
                        {
                            result = false;
                        }
                        break;
                    case "rightH_ID":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_rightH_ID)
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
        protected LinkedInstance relR8GLeft;
        // private DomainClassG relR8GLeft;
        protected LinkedInstance relR8HRight;
        // private DomainClassH relR8HRight;
        public bool LinkR8(DomainClassG oneInstanceLeft, DomainClassH otherInstanceRight, IList<ChangedState> changedStates=null)
        {
            bool result = false;
            if (relR8GLeft == null && relR8HRight == null)
            {
                this.attr_leftG_ID = oneInstanceLeft.Attr_G_ID;
                this.stateof_leftG_ID = true;
                this.attr_rightH_ID = otherInstanceRight.Attr_H_ID;
                this.stateof_rightH_ID = true;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:I(I_ID={this.Attr_I_ID}):link[One(G(G_ID={oneInstanceLeft.Attr_G_ID})),Other(H(H_ID={otherInstanceRight.Attr_H_ID}))]");

                result = (LinkedR8OneLeft()!=null) && (LinkedR8OtherRight()!=null);
                if (result)
                {
                    if (changedStates != null)
                    {
                        changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Create, Target = relR8GLeft });
                        changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Create, Target = relR8HRight });
                    }
                }
            }
            return result;
        }
        
        public bool UnlinkR8(DomainClassG oneInstanceLeft, DomainClassH otherInstanceRight, IList<ChangedState> changedStates=null)
        {
            bool result = false;
            if (relR8GLeft != null && relR8HRight != null)
            {
                if ((this.Attr_leftG_ID==oneInstanceLeft.Attr_G_ID) && (this.Attr_rightH_ID==otherInstanceRight.Attr_H_ID))
                {
                    if (changedStates != null)
                    {
                        changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Delete, Target = relR8GLeft });
                        changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Delete, Target = relR8HRight });
                    }
        
                    this.attr_leftG_ID = null;
                    this.stateof_leftG_ID = true;
                    this.attr_rightH_ID = null;
                    this.stateof_rightH_ID = true;
                    relR8GLeft = null;
                    relR8HRight = null;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:I(I_ID={this.Attr_I_ID}):unlink[G(G_ID={oneInstanceLeft.Attr_G_ID})]");

                    result = true;
                }
            }
            return result;
        }
        
        public DomainClassG LinkedR8OneLeft()
        {
            if (relR8GLeft == null)
            {
                var candidates = instanceRepository.GetDomainInstances("G").Where(inst=>(this.Attr_leftG_ID==((DomainClassG)inst).Attr_G_ID));
                if (candidates.Count() == 0)
                {
                   if (instanceRepository.ExternalStorageAdaptor != null) candidates = instanceRepository.ExternalStorageAdaptor.CheckTraverseStatus(DomainName, this, "G", "R8_Left", candidates, () => { return DomainClassGBase.CreateInstance(instanceRepository, logger); }, "any").Result;
                }
                relR8GLeft = new LinkedInstance() { Source = this, Destination = candidates.FirstOrDefault(), RelationshipID = "R8", Phrase = "Left" };
                // (DomainClassG)candidates.FirstOrDefault();
            }
            return relR8GLeft.GetDestination<DomainClassG>();
        }
        
        public DomainClassH LinkedR8OtherRight()
        {
            if (relR8HRight == null)
            {
                var candidates = instanceRepository.GetDomainInstances("H").Where(inst=>(this.Attr_rightH_ID==((DomainClassH)inst).Attr_H_ID));
                if (candidates.Count() == 0)
                {
                   if (instanceRepository.ExternalStorageAdaptor != null) candidates = instanceRepository.ExternalStorageAdaptor.CheckTraverseStatus(DomainName, this, "H", "R8_Right", candidates, () => { return DomainClassHBase.CreateInstance(instanceRepository, logger); }, "any").Result;
                }
                relR8HRight = new LinkedInstance() { Source = this, Destination = candidates.FirstOrDefault(), RelationshipID = "R8", Phrase = "Right" };
                // (DomainClassH)candidates.FirstOrDefault();
            }
            return relR8HRight.GetDestination<DomainClassH>();
        }

        public DomainClassOI LinkedR9OtherPrev()
        {
            var candidates = instanceRepository.GetDomainInstances("OI").Where(inst=>(this.Attr_I_ID==((DomainClassOI)inst).Attr_prevI_ID));
            if (candidates.Count() == 0)
            {
                if (instanceRepository.ExternalStorageAdaptor != null) candidates = instanceRepository.ExternalStorageAdaptor.CheckTraverseStatus(DomainName, this, "OI", "R9_Prev", candidates, () => { return DomainClassOIBase.CreateInstance(instanceRepository, logger); }, "any").Result;
                if (candidates.Count() > 0) ((DomainClassOI)candidates.FirstOrDefault()).LinkedR9OneNext();
            }
            return (DomainClassOI)candidates.FirstOrDefault();
        }


        public DomainClassOI LinkedR9OneNext()
        {
            var candidates = instanceRepository.GetDomainInstances("OI").Where(inst=>(this.Attr_leftG_ID==((DomainClassOI)inst).Attr_nextG_ID && this.Attr_rightH_ID==((DomainClassOI)inst).Attr_nextH_ID));
            if (candidates.Count() == 0)
            {
                if (instanceRepository.ExternalStorageAdaptor != null) candidates = instanceRepository.ExternalStorageAdaptor.CheckTraverseStatus(DomainName, this, "OI", "R9_Next", candidates, () => { return DomainClassOIBase.CreateInstance(instanceRepository, logger); }, "any").Result;
                if (candidates.Count() > 0) ((DomainClassOI)candidates.FirstOrDefault()).LinkedR9OtherPrev();
            }
            return (DomainClassOI)candidates.FirstOrDefault();
        }



        
        public bool Validate()
        {
            bool isValid = true;
            if (relR8GLeft == null)
            {
                isValid = false;
            }
            if (relR8HRight == null)
            {
                isValid = false;
            }
            return isValid;
        }

        public void DeleteInstance(IList<ChangedState> changedStates=null)
        {
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:I(I_ID={this.Attr_I_ID}):delete");

            changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Delete, Target = this, ChangedProperties = null });

            instanceRepository.Delete(this);
        }

        // methods for storage
        public void Restore(IDictionary<string, object> propertyValues)
        {
            if (propertyValues.ContainsKey("I_ID"))
            {
// should adopt timer setting
                attr_I_ID = (string)propertyValues["I_ID"];
            }
            stateof_I_ID = false;
            if (propertyValues.ContainsKey("leftG_ID"))
            {
// should adopt timer setting
                attr_leftG_ID = (string)propertyValues["leftG_ID"];
            }
            stateof_leftG_ID = false;
            if (propertyValues.ContainsKey("rightH_ID"))
            {
// should adopt timer setting
                attr_rightH_ID = (string)propertyValues["rightH_ID"];
            }
            stateof_rightH_ID = false;
        }
        
        public IDictionary<string, object> ChangedProperties()
        {
            var results = new Dictionary<string, object>();
            if (stateof_I_ID)
            {
                results.Add("I_ID", attr_I_ID);
                stateof_I_ID = false;
            }
            if (stateof_leftG_ID)
            {
                results.Add("leftG_ID", attr_leftG_ID);
                stateof_leftG_ID = false;
            }
            if (stateof_rightH_ID)
            {
                results.Add("rightH_ID", attr_rightH_ID);
                stateof_rightH_ID = false;
            }

            return results;
        }

        public string GetIdentities()
        {
            string identities = $"I_ID={this.Attr_I_ID}";

            return identities;
        }
        
        public IDictionary<string, object> GetProperties(bool onlyIdentity)
        {
            var results = new Dictionary<string, object>();

            if (!onlyIdentity) results.Add("I_ID", attr_I_ID);
            if (!onlyIdentity) results.Add("leftG_ID", attr_leftG_ID);
            if (!onlyIdentity) results.Add("rightH_ID", attr_rightH_ID);

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
