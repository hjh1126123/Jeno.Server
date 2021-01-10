using Jeno.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jeno.Common.Features
{
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class)]
    public class DI : Attribute
    {
        public DI(AutoFacInstanceType autoFacInstanceType = AutoFacInstanceType.Dependency)
        {
            AutoFacInstanceType = autoFacInstanceType;
        }

        public Enum.AutoFacInstanceType AutoFacInstanceType { get; set; }
    }
}
