using Asp.NetCore.Business.Interface;
using Asp.NetCore.EFCore.Models.Extend;
using Asp.NetCore.EFCore.Models.Models;
using Asp.NetCore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITbLogService _tbLogService = null;

        public HomeController(ILogger<HomeController> logger, ITbLogService tbLogService)
        {
            _logger = logger;
            this._tbLogService = tbLogService;
        }

        public IActionResult Index()
        {
            //using (LcDbContext context = new LcDbContext())
            //{
            //    context.TbLog.Find(1);
            //    //....
            //}
            //{
            //    ITbLogService service = new TbLogService(new LcDbContext());
            //    TbLog tblog= service.Find<TbLog>(1); 
            //}

            //{

            {
                var addlog = new TbLog()
                {
                    Info = "666",
                    Methodname = "777",
                    Mqpath = "888",
                    Mqpathid = 1,
                    Createtime = DateTime.Now,
                    Updatetime = DateTime.Now
                };
                //如果Insert进去以后，马上就去查询的，我也建议大家直接基于主库来；
                //因为数据库读写分离以后，数据同步会有延迟；
                var t = _tbLogService.Insert(addlog);
                TbLog tblog1 = _tbLogService.Find<TbLog>(t.Id, WriteAndReadEnum.Write);
                TbLog tblog2 = _tbLogService.Find<TbLog>(11);
                TbLog tblog3 = _tbLogService.Find<TbLog>(11);
                TbLog tblog4 = _tbLogService.Find<TbLog>(11);
            }

            {
                TbLog tbLog = _tbLogService.Find<TbLog>(4);
            }
            {

                TbLog tbLog = _tbLogService.Find<TbLog>(1);
                //做一系列的操作
                //做数据库跟新
                //tbLog.LastModifyTime = DateTime.Now;
                //_tbLogService.Update(tbLog);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
