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
using Logistics.IDAL.IStaff;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using Logistics.Common.Filter;
using Autofac;
using System.Reflection;

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
            services.AddControllers(options =>
            {
                options.Filters.Add<CustomerExceptionFilter>();
            });


            Connection.MSSql = Configuration.GetConnectionString("default");//��ȡjson�ļ������ݿ������ַ�������connection����mssql�ֶ�

            var jwtConfig = Configuration.GetSection("Jwt");
            //������Կ
            var symmetricKeyAsBase64 = jwtConfig.GetValue<string>("Secret");
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            //��֤����
            services.AddAuthentication("Bearer")
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,//�Ƿ���֤ǩ��,����֤�Ļ����Դ۸����ݣ����� ȫ
                        IssuerSigningKey = signingKey,//���ܵ���Կ
                        ValidateIssuer = true,//�Ƿ���֤�����ˣ�������֤�غ��е�Iss�Ƿ��Ӧ ValidIssuer����
                        ValidIssuer = "������",//������
                        ValidateAudience = true,//�Ƿ���֤�����ˣ�������֤�غ��е�Aud�Ƿ��Ӧ ValidAudience����
                        ValidAudience = "����",//������
                        ValidateLifetime = true,//�Ƿ���֤����ʱ�䣬�����˾;ܾ�����
                        ClockSkew = TimeSpan.Zero,//����ǻ������ʱ�䣬Ҳ����˵����ʹ���������˹��� ʱ�䣬����ҲҪ���ǽ�ȥ������ʱ��+���壬Ĭ�Ϻ�����7���ӣ������ֱ������Ϊ0
                        RequireExpirationTime = true,
                    };
                });


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


            //services.AddControllers(options =>
            //{
            //    options.Filters.Add<CustomerExceptionFilter>();
            //});

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Logistics.API", Version = "v1" });


                //����ע��
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);

                var xmlPath = Path.Combine(basePath, "Logistics.API.xml");

                c.IncludeXmlComments(xmlPath);

                #region swagger��JWT��֤
                //����Ȩ��С��
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                //��header�����token�����ݵ���̨
                c.OperationFilter<SecurityRequirementsOperationFilter>();
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���)ֱ���������������Bearer {token}(ע������֮����һ���ո�) \"",
                    Name = "Authorization",// tĬ�ϵĲ�������
                    In = ParameterLocation.Header,// tĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
                    Type = SecuritySchemeType.ApiKey
                });
                #endregion                                                                                                                      In = ParameterLocation.Header,//jwtĬ�ϴ�� Authorization��Ϣ��λ��(����ͷ��)Type = SecuritySchemeType.ApiKey }); c.AddSecurityRequirement(new OpenApiSecurityRequirement { { new OpenApiSecurityScheme { Reference = new OpenApiReference() { Id = "Bearer", Type = ReferenceType.SecurityScheme } }, Array.Empty<string>() } });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// //�÷���������ʱ���á�ʹ�ô˷�������HTTP����ܵ���
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Logistics.API v1"));
            }

            loggerFactory.AddLog4Net();//ע��logger�м��

            app.UseRouting();

            app.UseCors();            //��ӿ����м��

            app.UseAuthentication(); //����������֤��
            app.UseAuthorization(); //����Ƿ������Դ�����Ȩ

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        /// <summary>
        /// ʹ�õ�����ioc���� autofacʵ��ע�����
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //����ע��builder.RegisterType<UserDal>().As<IUser>();

            Assembly server = Assembly.Load("Logistics.DAL");//��ȡ��ʵ����������ռ�

            builder.RegisterAssemblyTypes(server)
                .AsImplementedInterfaces()
                .InstancePerDependency();       //ʵ������ע��
        }
    }
}
