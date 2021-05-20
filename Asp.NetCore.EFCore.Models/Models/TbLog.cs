using System;
using System.Collections.Generic;

#nullable disable

namespace Asp.NetCore.EFCore.Models.Models
{
    public partial class TbLog
    {
        public long Id { get; set; }
        public int Mqpathid { get; set; }
        public string Mqpath { get; set; }
        public string Methodname { get; set; }
        public string Info { get; set; }
        public DateTime Createtime { get; set; }
        public DateTime? Updatetime { get; set; }
    }
}
