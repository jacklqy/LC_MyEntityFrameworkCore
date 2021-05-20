using Asp.NetCore.Business.Interface;
using Asp.NetCore.EFCore.Models.Extend;
using Asp.NetCore.EFCore.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.Business.Service
{
    public class TbLogService : BaseService, ITbLogService
    {

        public TbLogService(IDbContextFactory contextFactory) : base(contextFactory)
        {

        }

        /// <summary>
        /// 直接指定为主库
        /// </summary>
        /// <param name="Id"></param>
        public void DeleteCompanyAndUser(long Id)
        { 
            {
                _Context = _ContextFactory.ConnWriteOrRead(WriteAndReadEnum.Read);
                TbLog tbLog = this.Find<TbLog>(Id, WriteAndReadEnum.Write);//也可以附加
                if (tbLog == null) throw new Exception("t is null");

                //从主库删除数据，这样才会同步到从库，否则...
                _Context = _ContextFactory.ConnWriteOrRead(WriteAndReadEnum.Write);
                this._Context.Set<TbLog>().Remove(tbLog);
            }
            {
                //从主库删除数据，这样才会同步到从库，否则...
                TbLog tlog = this.Find<TbLog>(Id, WriteAndReadEnum.Write);//也可以附加
                if (tlog == null) throw new Exception("t is null");
                this._Context.Set<TbLog>().Remove(tlog);
            }
            {
                //自己定义Service 的时候，一般都是删除、查询综合使用；
                //业务逻辑相对复杂；
                //建议：就直接从主库操作，避免因增删改从库后，无法同步问题。因为只能从主库同步到从库。可以考虑将从库设置为不允许程序增删改，只允许读。

            }

            this.Commit();
        }
    }
}