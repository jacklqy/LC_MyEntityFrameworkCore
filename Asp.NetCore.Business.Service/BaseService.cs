using Asp.NetCore.Business.Interface;
using Asp.NetCore.EFCore.Models.Extend;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.Business.Service
{

    /// <summary>
    /// 支持数据库读写分离：
    /// 多个数据库
    /// DB-1 主库;
    /// DB-2；
    /// 
    /// 二八原则： 20%业务是增删改  80% 查询
    /// 
    /// 增删改---主库
    /// 查询--从库
    /// 
    /// 需要多个连接； 有一个连接是主库   多个连接是从库；
    /// 20%---主库连接   80%---从库的链接
    /// 
    ///根据不同的操作来确定不同的链接；
    ///上端需要传递枚举；传递枚举其实是指定不同的Context的链接
    /// ？？？
    /// 来一个工厂；
    /// 
    /// </summary>
    public class BaseService : IBaseService, IDisposable
    { 
        protected IDbContextFactory _ContextFactory = null;
        protected DbContext _Context { get; set; }

        public BaseService(IDbContextFactory contextFactory)
        {
            _ContextFactory = contextFactory;
        }

        /// <summary>
        /// 主库  即可以读取也可以增删改；
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="writeAndReadEnum"></param>
        /// <returns></returns>
        public T Find<T>(long id, WriteAndReadEnum writeAndReadEnum= WriteAndReadEnum.Read) where T : class
        {
            //确定链接---从库
            _Context = _ContextFactory.ConnWriteOrRead(writeAndReadEnum);
            return this._Context.Set<T>().Find(id);
        }

        public T Insert<T>(T t) where T : class
        {
            //确定链接---主库
            _Context = _ContextFactory.ConnWriteOrRead(WriteAndReadEnum.Write);
            this._Context.Set<T>().Add(t);
            this.Commit();//写在这里  就不需要单独commit  不写就需要 
            return t;
        }
        public void Delete<T>(long Id) where T : class
        {
            _Context = _ContextFactory.ConnWriteOrRead(WriteAndReadEnum.Write);
            T t = this.Find<T>(Id);//也可以附加
            if (t == null) throw new Exception("t is null");
            this._Context.Set<T>().Remove(t);
            this.Commit();
        }

        public void Delete<T>(T t) where T : class
        {
            _Context = _ContextFactory.ConnWriteOrRead(WriteAndReadEnum.Write);
            if (t == null) throw new Exception("t is null");
            this._Context.Set<T>().Attach(t);
            this._Context.Set<T>().Remove(t);
            this.Commit();
        }

        public void Commit()
        {
            this._Context.SaveChanges();
        }

        public void Dispose()
        {
            if (this._Context != null)
            {
                this._Context.Dispose();
            }
        } 
    }
}
