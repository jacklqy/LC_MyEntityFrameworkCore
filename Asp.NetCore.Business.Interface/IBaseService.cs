using Asp.NetCore.EFCore.Models.Extend;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.Business.Interface
{
    public interface IBaseService:IDisposable
    {
        #region Query
        /// <summary>
        /// 根据id查询实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Find<T>(long id, WriteAndReadEnum writeAndReadEnum = WriteAndReadEnum.Read) where T : class;

        #endregion

        #region Add
        /// <summary>
        /// 新增数据，即时Commit
        /// </summary>
        /// <param name="t"></param>
        /// <returns>返回带主键的实体</returns>
        public T Insert<T>(T t) where T : class;
        #endregion

        #region Delete
        /// <summary>
        /// 根据主键删除数据，即时Commit
        /// </summary>
        /// <param name="t"></param>
        public void Delete<T>(long Id) where T : class;

        public void Delete<T>(T t) where T : class;

        #endregion

        #region Other
        /// <summary>
        /// 立即保存全部修改
        /// 把增/删的savechange给放到这里，是为了保证事务的
        /// </summary>
        void Commit();

        #endregion
    }
}
