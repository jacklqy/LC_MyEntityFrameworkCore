using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.EFCore.Models.Models
{
    public static class LcDbContextExtend
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
