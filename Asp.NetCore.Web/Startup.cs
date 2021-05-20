using Asp.NetCore.Business.Interface;
using Asp.NetCore.Business.Service;
using Asp.NetCore.EFCore.Models.Extend;
using Asp.NetCore.EFCore.Models.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //AspNetCore 注册服务

            ///可以在这里指定生命周期； 在这里控制；
            services.AddTransient<ITbLogService, TbLogService>();
            services.AddTransient<DbContext, LcDbContext>();
            //services.AddTransient<DbContext, EFCoreContext01>();
            ///可以获取DbContext 实例的集合；

            services.AddTransient<IDbContextFactory, DbContextFactory>();
            services.Configure<DBConnectionOption>(Configuration.GetSection("ConnectionStrings"));//注入多个数据库链接
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
