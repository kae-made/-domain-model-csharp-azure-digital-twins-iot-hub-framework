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
using Kae.StateMachine;
using Kae.DomainModel.Csharp.Framework;

namespace ADTTestModel
{

    public interface DomainClassOOD : DomainClassDef
    {
        // Conceptual Information Class's Properties

        string Attr_OodId { get; }
        string Attr_left_LiefDeviceId { get; }
        string Attr_right_LiefDeviceId { get; }


        // Relationships 

        public bool LinkR3(DomainClassLD oneInstanceRight, DomainClassLD otherInstanceLeft, IList<ChangedState> changedStates=null);
        public bool UnlinkR3(DomainClassLD oneInstanceRight, DomainClassLD otherInstanceLeft, IList<ChangedState> changedStates=null);
        public DomainClassLD LinkedR3OneRight();
        public DomainClassLD LinkedR3OtherLeft();


        // Conceptual Information Class's Operations



    }

    public interface DomainClassTS : DomainClassDef
    {
        // Conceptual Information Class's Properties

        string Attr_TSId { get; }


        // Relationships 


        public SubClassR4 GetSubR4();

        public DomainClassSC1 LinkedR4SC1();

        public DomainClassSC2 LinkedR4SC2();


        // Conceptual Information Class's Operations



    }

    public interface DomainClassTE : DomainClassDef
    {
        // Conceptual Information Class's Properties

        string Attr_TopEntityId { get; }
        int Attr_X { get; set; }
        string Attr_S { get; set; }
        int Attr_TestInterval { get; set; }


        // Relationships 


        public IEnumerable<DomainClassME> LinkedR1Child();


        // Conceptual Information Class's Operations

        public int GetNumberOfLiefDevices();



    }

    public interface DomainClassW : DomainClassDef
    {
        // Conceptual Information Class's Properties

        string Attr_WId { get; }
        int Attr_current_state { get; }
        string Attr_LiefDeviceId { get; }


        // State Machine

        void TakeEvent(EventData domainEvent, bool selfEvent=false);

        // Relationships 

        public DomainClassLD LinkedR6Target();

        public bool LinkR6Target(DomainClassLD instance, IList<ChangedState> changedStates=null);

        public bool UnlinkR6Target(DomainClassLD instance, IList<ChangedState> changedStates=null);


        // Conceptual Information Class's Operations



    }

    public interface DomainClassSC2 : DomainClassDef, SubClassR4
    {
        // Conceptual Information Class's Properties

        string Attr_TSId { get; }


        // Relationships 

        public bool LinkR4(DomainClassTS instance, IList<ChangedState> changedStates=null);
        public bool UnlinkR4(DomainClassTS instance, IList<ChangedState> changedStates=null);


        // Conceptual Information Class's Operations



    }

    public interface DomainClassSC1 : DomainClassDef, SubClassR4
    {
        // Conceptual Information Class's Properties

        string Attr_TSId { get; }


        // Relationships 

        public bool LinkR4(DomainClassTS instance, IList<ChangedState> changedStates=null);
        public bool UnlinkR4(DomainClassTS instance, IList<ChangedState> changedStates=null);


        // Conceptual Information Class's Operations



    }

    public interface DomainClassME : DomainClassDef
    {
        // Conceptual Information Class's Properties

        string Attr_MiddleEntityId { get; }
        string Attr_TopEntityId { get; }
        bool Attr_Comfortable { get; set; }
        int Attr_PreferredTemperature { get; set; }
        int Attr_PreferredHumidity { get; set; }


        // Relationships 

        public DomainClassTE LinkedR1();

        public bool LinkR1(DomainClassTE instance, IList<ChangedState> changedStates=null);

        public bool UnlinkR1(DomainClassTE instance, IList<ChangedState> changedStates=null);

        public IEnumerable<DomainClassLD> LinkedR2Measurement();
        public DomainClassMML LinkedR5OtherLief();


        // Conceptual Information Class's Operations

        public void Command(string order);



    }

    public interface DomainClassMML : DomainClassDef
    {
        // Conceptual Information Class's Properties

        string Attr_MMLId { get; }
        string Attr_MiddleEntityId { get; }
        string Attr_LiefDeviceId { get; }


        // Relationships 

        public bool LinkR5(DomainClassME oneInstanceMiddle, DomainClassLD otherInstanceLief, IList<ChangedState> changedStates=null);
        public bool UnlinkR5(DomainClassME oneInstanceMiddle, DomainClassLD otherInstanceLief, IList<ChangedState> changedStates=null);
        public DomainClassME LinkedR5OneMiddle();
        public DomainClassLD LinkedR5OtherLief();


        // Conceptual Information Class's Operations



    }

    public interface DomainClassLD : DomainClassDef
    {
        // Conceptual Information Class's Properties

        string Attr_LiefDeviceId { get; }
        DomainTypeEnvironmentPhysicalQuantities Attr_Environment { get; set; }
        int Attr_Number { get; set; }
        string Attr_MiddleEntityId { get; }
        int Attr_RequestInterval { get; set; }
        int Attr_CurrentInterval { get; set; }
        string Attr_DeviceStatus { get; set; }
        int Attr_current_state { get; }


        // State Machine

        void TakeEvent(EventData domainEvent, bool selfEvent=false);

        // Relationships 

        public DomainClassME LinkedR2();

        public bool LinkR2(DomainClassME instance, IList<ChangedState> changedStates=null);

        public bool UnlinkR2(DomainClassME instance, IList<ChangedState> changedStates=null);
        public DomainClassOOD LinkedR3OtherLeft();

        public DomainClassOOD LinkedR3OneRight();

        public DomainClassMML LinkedR5OneMiddle();
        public DomainClassW LinkedR6();


        // Conceptual Information Class's Operations

        public void Command(string order);

        public void MeasureEnvironment();

        public string CommandWithResult(int mode, string operation);

        public void CommandForDomain();



    }
}
