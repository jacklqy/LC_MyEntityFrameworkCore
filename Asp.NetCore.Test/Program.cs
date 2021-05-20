using Asp.NetCore.EFCore.Models;
using System;

namespace Asp.NetCore.Test
{
    //1.EFCore 迁移，多种映射方式
    //2.EFCore支持Linq复杂查询
    //3.导航属性、状态跟踪、级联删除
    //4.记录日志/支持索引配置/查询调优
    //5.表拆分、多实体对应数据库单表
    //6.事务问题、扩展定制SaveChange
    class Program
    {
        /// <summary>
        /// 上端
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                using (LcDbContext context = new LcDbContext())
                {
                    {
                        //context.Database.EnsureDeleted();
                        //context.Database.EnsureCreated();
                    }
                    {
                        //var Addcompany = new Company()
                        //{
                        //    CompanyName = "朝夕教育",
                        //    CreateTime = DateTime.Now,
                        //    CreatorId = 1,
                        //    Description = "专注于培养新一代C#.Net技术精英",
                        //    LastModifyTime = DateTime.Now,
                        //    LastModifierId = 1
                        //};

                        //context.Conmpany.Add(Addcompany);
                        //context.SaveChanges(); 
                        //Company company = context.Conmpany.Find(1); 
                        //var companyList = context.Conmpany.Where(c => c.Id > 1);
                    }
                    {
                        //EFCore支持Linq查询；  
                        QueryTest.Show();
                    }
                    {
                        //NavigationTest.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
