using Asp.NetCore.EFCore.Models;
using Asp.NetCore.EFCore.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asp.NetCore.Test
{
    public class NavigationTest
    {
        public static void Show()
        {
            using (LcDbContext context = new LcDbContext())
            {
                {
                    /////可以一次添加复杂对象
                    //var company = new Company()
                    //{
                    //    Name = "朝夕教育",
                    //    CreateTime = DateTime.Now,
                    //    CreatorId = 1,
                    //    Description = "专注于培养新一代C#.Net技术精英",
                    //    LastModifyTime = DateTime.Now,
                    //    LastModifierId = 1,
                    //    SysUser = new List<SysUser>() {
                    //        new SysUser() {
                    //            Name = "Richard 老师",
                    //            Mobile = "18672713698",
                    //            CreateTime = DateTime.Now,
                    //            Password="123456789"
                    //        },
                    //        new SysUser() {
                    //            Name = "Eleven 老师",
                    //            Mobile = "18672713698",
                    //            CreateTime = DateTime.Now,
                    //            Password="123456789"
                    //        },
                    //        new SysUser() {
                    //            Name = "Apple老师",
                    //            Mobile = "18672713698",
                    //            CreateTime = DateTime.Now,
                    //            Password="123456789"
                    //        }
                    //    }
                    //};
                    //context.Conmpany.Add(company);
                    //context.SaveChanges();
                }
                {
                    ////在EFCore 里面默认是不加载导航属性的数据；
                    //List<Company> companyList = context.Conmpany.Include(c=>c.SysUser).ToList(); 
                    //// Include 
                    ////List<Company> companyList1 = context.Conmpany.Include(c => c.SysUser).ToList(); 
                    //foreach (Company company in companyList)
                    //{
                    //    var userList = company.SysUser;
                    //    foreach (var user in userList)
                    //    {
                    //        var cmpy = user.Company;
                    //        foreach (var item in cmpy.SysUser) //无限循环的
                    //        { 

                    //        }
                    //    }
                    //}
                }
                {
                    //context.SysLog.Add(new SysLog()
                    //{
                    //    LogType = new byte(),
                    //    UserName = "Richard 老师",
                    //    SysLogDetail = new SysLogDetail()
                    //    {
                    //        CreateTime = DateTime.Now,
                    //        Introduction = "架构班的VIP课程",
                    //        CreatorId = 1,
                    //        LastModifierId = 1,
                    //        LastModifyTime = DateTime.Now
                    //    }
                    //});
                    //context.SaveChanges(); 
                    //SysLog sysLog= context.SysLog.FirstOrDefault();
                    //SysLogDetail sysLogDetail= context.SysLogDetail.FirstOrDefault();
                }

                {

                    ////Include:预先加载
                    ////ThenInclude: 多个层架的预先加载
                    //Company company = context.Conmpany.Include(c => c.SysUser).FirstOrDefault();
                    //foreach (SysUser user in company.SysUser)
                    //{
                    //    Company company1 = user.Company;
                    //    foreach (var item in company1.SysUser)
                    //    {

                    //    }
                    //}
                }
                //
                //{
                //    Company company = context.Conmpany.Include(c => c.SysUser).FirstOrDefault(); 
                //    foreach (SysUser user in company.SysUser)
                //    {
                //        Company company1 = user.Company;
                //        foreach (var item in company1.SysUser)
                //        {

                //        }
                //    }


                //    Company company2 = context.Conmpany.FirstOrDefault();
                //    foreach (SysUser user in company2.SysUser)
                //    {
                //        Company company3 = user.Company;
                //        foreach (var item in company3.SysUser)
                //        {

                //        }
                //    }
                //}
            }
        }
    }
}
