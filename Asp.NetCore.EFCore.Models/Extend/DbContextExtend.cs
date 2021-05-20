using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.EFCore.Models.Extend
{
    /// <summary>
    /// DbContext扩展
    /// </summary>
    public static class DbContextExtend
    { 
        public static DbContext ToWriteOrRead(this DbContext dbContext, string conn)
        {
            if (dbContext is LcDbContext)
            {

                var context= (LcDbContext)dbContext; // context 是 LcDbContext 实例；

                return context.ToWriteOrRead(conn);
            }
            else
                throw new Exception();
        }
    }
}
