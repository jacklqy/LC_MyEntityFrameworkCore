using Asp.NetCore.EFCore.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asp.NetCore.Test
{
    public class QueryTest
    {
        public static void Show()
        {
            #region 其他查询
            using (LcDbContext dbContext = new LcDbContext())
            {
                {
                    //var list = dbContext.SysUser.Where(u => 1 == 1 && !(new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14, 17 }.Contains(u.Id)));//in查询
                    //foreach (var user in list)
                    //{
                    //    System.Console.WriteLine(user.UserName);
                    //}
                }
                {
                    //var list = from u in dbContext.SysUser
                    //           where new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14, 17 }.Contains(u.Id)
                    //           select u;

                    //foreach (var user in list)
                    //{
                    //    System.Console.WriteLine(user.UserName);
                    //}
                }
                {
                    //var list = dbContext.SysUser.Where(u => new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14, 17 }.Contains(u.Id))
                    //                          .OrderBy(u => u.Id) //排序 
                    //                          .Select(u => new //投影
                    //                          {
                    //                              Name = u.Name,
                    //                              Pwd = u.Password
                    //                          }).Skip(3).Take(5); //跳过三条  再获取5条
                    //foreach (var user in list)
                    //{
                    //    System.Console.WriteLine(user.Name);
                    //}
                }
                {
                    //var list = dbContext.SysUser.Where(u => u.Name.StartsWith("Richard") && u.Name.EndsWith("老师"))
                    //  .Where(u => u.Name.EndsWith("老师"))
                    //  .Where(u => u.Name.Contains("Richard"))
                    //  .Where(u => u.Name.Length < 10)
                    //  .OrderBy(u => u.Id);

                    //foreach (var user in list)
                    //{
                    //    System.Console.WriteLine(user.Name);
                    //}
                }
                {
                    //var list = from u in dbContext.SysUser
                    //           join c in dbContext.SysUserRoleMapping on u.Id equals c.SysUserId
                    //           where new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14, 17 }.Contains(u.Id)
                    //           select new
                    //           {
                    //               Name = u.Name,
                    //               Pwd = u.Password,
                    //               RoleId = c.SysRoleId
                    //           };
                    //foreach (var user in list)
                    //{
                    //    System.Console.WriteLine("{0} {1}", user.Name, user.Pwd);
                    //}
                }
                {
                    //var list = from u in dbContext.SysUser
                    //           join m in dbContext.SysUserRoleMapping on u.Id equals m.SysUserId
                    //           join r in dbContext.SysRole on m.SysRoleId equals r.Id
                    //           where new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14, 17 }.Contains(u.Id)
                    //           select new
                    //           {
                    //               Name = u.Name,
                    //               Pwd = u.Password,
                    //               RoleId = m.SysRoleId,
                    //               RoleName = r.Name
                    //           };
                    //foreach (var user in list)
                    //{
                    //    System.Console.WriteLine("{0} {1} {2}", user.Name, user.Pwd, user.RoleName);
                    //}
                }
            }

            using (LcDbContext dbContext = new LcDbContext())
            {
                {
                    try
                    {
                        string sql = "Update dbo.SysUser Set Password='Ricahrd老师-小王子' WHERE Id=@Id";
                        SqlParameter parameter = new SqlParameter("@Id", 1);
                        int flag = dbContext.Database.ExecuteSqlRaw(sql, parameter);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            //TransactionScope 在EFCore 里面 用不了。。。 框架现在还不支持。。后续应该会支持。。。
            using (LcDbContext dbContext = new LcDbContext())
            {
                {
                    //事务
                    IDbContextTransaction trans = null;
                    try
                    {
                        trans = dbContext.Database.BeginTransaction();
                        string sql = "Update dbo.SysUser Set Password='Ricahrd老师-小王子' WHERE Id=@Id";
                        SqlParameter parameter = new SqlParameter("@Id", 10);
                        dbContext.Database.ExecuteSqlRaw(sql, parameter);
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (trans != null)
                            trans.Rollback();
                        throw ex;
                    }
                    finally
                    {
                        trans.Dispose();
                    }
                }
            }
            #endregion

        }
    }
}
