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
        /// //�÷���������ʱ���á�ʹ�ô˷�����������ӷ��񡣡�
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IUser, UserDal>();//����û�ע�����
            services.AddSingleton<IRole, RoleDal>();//��ɫע��
            services.AddSingleton<IPower, PowerDal>();//�˵�ע��
            services.AddSingleton<ICar, CarDal>();//����ע��
            services.AddSingleton<IStaffInfo, StaffInfoDal>();

            Connection.MSSql = Configuration.GetConnectionString("default");//��ȡjson�ļ������ݿ������ַ�������connection����mssql�ֶ�

            //ע��������
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


                //����ע��
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);

                var xmlPath = Path.Combine(basePath, "Logistics.API.xml");

                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// //�÷���������ʱ���á�ʹ�ô˷�������HTTP����ܵ���
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

            app.UseCors();            //��ӿ����м��

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
