using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logistics.IDAL;
using Logistics.IDAL.Istaff;
using Logistics.DAL.Staff;
using Logistics.DAL;
using System.IO;
using Logistics.Common;

namespace Logistics.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// //该方法由运行时调用。使用此方法向容器添加服务。”
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IUser, UserDal>();//添加用户注入服务
            services.AddSingleton<IRole, RoleDal>();//角色注入
            services.AddSingleton<IPower, PowerDal>();//菜单注入
            services.AddSingleton<ICar, CarDal>();//车辆注入
            services.AddSingleton<IStaffInfo, StaffInfoDal>();

            Connection.MSSql = Configuration.GetConnectionString("default");//获取json文件中数据库连接字符串存入connection类中mssql字段

            //注册跨域服务
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyHeader();
                        builder.AllowAnyOrigin();
                    });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Logistics.API", Version = "v1" });


                //方法注解
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);

                var xmlPath = Path.Combine(basePath, "Logistics.API.xml");

                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// //该方法由运行时调用。使用此方法配置HTTP请求管道。
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Logistics.API v1"));
            }

            app.UseRouting();

            app.UseCors();            //添加跨域中间件

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
