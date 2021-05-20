using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.EFCore.Models.Extend
{
    /// <summary>
    /// 数据库操作枚举
    /// </summary>
    public enum WriteAndReadEnum
    {
        /// <summary>
        /// 主库操作--增删改，也可以查
        /// </summary>
        Write,
        /// <summary>
        /// 从库操作--读
        /// </summary>
        Read 
    }
}
