using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.EFCore.Models.Extend
{
    public class DBConnectionOption
    {
        public string WriteConnection { get; set; }
        public List<string> ReadConnectionList { get; set; }
    }
}
