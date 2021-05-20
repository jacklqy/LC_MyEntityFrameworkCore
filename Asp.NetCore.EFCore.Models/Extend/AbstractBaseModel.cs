using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.EFCore.Models.Extend
{
    public abstract class AbstractBaseModel
    {
        public abstract DateTime? LastModifyTime { get; set; }
    }
}
