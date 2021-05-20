using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.EFCore.Models.Extend
{
    /// <summary>
    /// 主从数据库连接字符串配置项
    /// </summary>
    public class DBConnectionOption
    {
        /// <summary>
        /// 主库连接字符串
        /// </summary>
        public string WriteConnection { get; set; }
        /// <summary>
        /// 从库连接字符串集合
        /// </summary>
        public List<string> ReadConnectionList { get; set; }
    }
}
