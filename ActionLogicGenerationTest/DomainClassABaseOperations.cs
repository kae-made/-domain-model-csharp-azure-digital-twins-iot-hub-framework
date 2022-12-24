// ------------------------------------------------------------------------------
// <auto-generated>
//     This file is generated by tool.
//     Runtime Version : 1.0.0
//  
// </auto-generated>
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Kae.StateMachine;
using Kae.DomainModel.Csharp.Framework;
using Kae.DomainModel.Csharp.Framework.Adaptor.ExternalStorage;

namespace ActionLogicGenerationTest
{
    partial class DomainClassABase
    {
        public int SetTest(string s, int x)
        {
            // TODO : Let's write code!
            // Action Description on Model as a reference
            //  1 : SELF.Name = param.s;
            //  2 : SELF.Number = param.x;
            //  3 : RETURN SELF.Number + 2;

            var changedStates = new List<ChangedState>();
            // Generated from action description
                // Line : 1
                this.Attr_Name = s;
                // Line : 2
                this.Attr_Number = x;
                // Line : 3
                instanceRepository.SyncChangedStates(changedStates);
                return (this.Attr_Number + 2);


        }


    }
}