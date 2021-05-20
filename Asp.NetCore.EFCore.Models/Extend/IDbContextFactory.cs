using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.EFCore.Models.Extend
{
    public  interface IDbContextFactory
    {
        public DbContext ConnWriteOrRead(WriteAndReadEnum writeAndRead);
    }
}
