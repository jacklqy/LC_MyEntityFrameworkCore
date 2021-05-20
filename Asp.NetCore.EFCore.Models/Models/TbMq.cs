using System;
using System.Collections.Generic;

#nullable disable

namespace Asp.NetCore.EFCore.Models.Models
{
    public partial class TbMq
    {
        public int Id { get; set; }
        public string Mqname { get; set; }
        public DateTime Createtime { get; set; }
    }
}
