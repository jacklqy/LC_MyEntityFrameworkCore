using Asp.NetCore.EFCore.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.EFCore.Models.Extend
{
    public class DbContextFactory : IDbContextFactory
    {

        private DbContext _Context = null;

        private DBConnectionOption _readAndWrite = null;

        /// <summary>
        ///能把链接信息也注入进来
        ///需要IOptionsMonitor
        /// </summary>
        /// <param name="context"></param>
        public DbContextFactory(DbContext context, IOptionsMonitor<DBConnectionOption> options)
        {
            this._readAndWrite = options.CurrentValue;
            this._Context = context;
        }
        public DbContext ConnWriteOrRead(WriteAndReadEnum writeAndRead)
        {
            //判断枚举，不同的枚举更换Context链接；
            switch (writeAndRead)
            {
                case WriteAndReadEnum.Write:
                    ToWrite();
                    break;
                case WriteAndReadEnum.Read:
                    ToRead();
                    break;
                default:
                    throw new Exception("wrong WriteAndReadEnum...");
            }
            return _Context;
        }
         
        /// <summary>
        /// 更换成主库连接
        /// </summary>
        /// <returns></returns>
        private void ToWrite()
        {
            string conn= _readAndWrite.WriteConnection;
            //_Context.Database.GetDbConnection().ConnectionString=conn;
            _Context.ToWriteOrRead(conn); 
        }


        private static int _iSeed = 0;
        /// <summary>
        /// 更换成从库连接
        /// 策略：数据库查询的负载均衡
        /// </summary>
        /// <returns></returns>
        private void ToRead()
        {
            string conn = string.Empty;
            {
               // //随机
               //int Count=  _readAndWrite.ReadConnectionList.Count;
               //int index=  new Random().Next(0, Count);
               //conn = _readAndWrite.ReadConnectionList[index];
            }
            {
                //来一个轮询（并发多线程的情况下_iSeed考虑加锁）
                conn = this._readAndWrite.ReadConnectionList[_iSeed++ % this._readAndWrite.ReadConnectionList.Count];//轮询;  
            }
            { 
                ///是不是可以直接配置到配置文件里面
            }
            _Context.ToWriteOrRead(conn);
        }

    }
}
