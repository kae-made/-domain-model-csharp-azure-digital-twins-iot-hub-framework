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
using System.Reflection;
using Kae.Utility.Logging;
using Kae.DomainModel.Csharp.Framework;

namespace ADTTestModel
{
    public partial class CIMADTTestModelLib
    {
        protected InstanceRepository instanceRepository;
        public static readonly string DomainName = "ADTTestModel";

        public CIMADTTestModelLib(InstanceRepository instanceRepository)
        {
            this.instanceRepository = instanceRepository;
        }

        protected Logger logger;

        public Logger Logger { get { return logger; } set { logger = value; } }

        public InstanceRepository InstanceRepository { get { return instanceRepository; } }

    }
}