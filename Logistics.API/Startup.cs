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
        /// //该方法由运行时调用。使用此方法向容器添加服务。”
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<CustomerExceptionFilter>();
            });


            Connection.MSSql = Configuration.GetConnectionString("default");//获取json文件中数据库连接字符串存入connection类中mssql字段

            var jwtConfig = Configuration.GetSection("Jwt");
            //生成密钥
            var symmetricKeyAsBase64 = jwtConfig.GetValue<string>("Secret");
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            //认证参数
            services.AddAuthentication("Bearer")
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,//是否验证签名,不验证的画可以篡改数据，不安 全
                        IssuerSigningKey = signingKey,//解密的密钥
                        ValidateIssuer = true,//是否验证发行人，就是验证载荷中的Iss是否对应 ValidIssuer参数
                        ValidIssuer = "徐征欢",//发行人
                        ValidateAudience = true,//是否验证订阅人，就是验证载荷中的Aud是否对应 ValidAudience参数
                        ValidAudience = "张三",//订阅人
                        ValidateLifetime = true,//是否验证过期时间，过期了就拒绝访问
                        ClockSkew = TimeSpan.Zero,//这个是缓冲过期时间，也就是说，即使我们配置了过期 时间，这里也要考虑进去，过期时间+缓冲，默认好像是7分钟，你可以直接设置为0
                        RequireExpirationTime = true,
                    };
                });


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


            //services.AddControllers(options =>
            //{
            //    options.Filters.Add<CustomerExceptionFilter>();
            //});

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Logistics.API", Version = "v1" });


                //方法注解
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);

                var xmlPath = Path.Combine(basePath, "Logistics.API.xml");

                c.IncludeXmlComments(xmlPath);

                #region swagger用JWT验证
                //开启权限小锁
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                //在header中添加token，传递到后台
                c.OperationFilter<SecurityRequirementsOperationFilter>();
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传递)直接在下面框中输入Bearer {token}(注意两者之间是一个空格) \"",
                    Name = "Authorization",// t默认的参数名称
                    In = ParameterLocation.Header,// t默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });
                #endregion                                                                                                                      In = ParameterLocation.Header,//jwt默认存放 Authorization信息的位置(请求头中)Type = SecuritySchemeType.ApiKey }); c.AddSecurityRequirement(new OpenApiSecurityRequirement { { new OpenApiSecurityScheme { Reference = new OpenApiReference() { Id = "Bearer", Type = ReferenceType.SecurityScheme } }, Array.Empty<string>() } });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// //该方法由运行时调用。使用此方法配置HTTP请求管道。
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

            loggerFactory.AddLog4Net();//注册logger中间件

            app.UseRouting();

            app.UseCors();            //添加跨域中间件

            app.UseAuthentication(); //这个是添加认证的
            app.UseAuthorization(); //这个是方法里自带的授权

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        /// <summary>
        /// 使用第三方ioc容器 autofac实现注入服务
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //单个注入builder.RegisterType<UserDal>().As<IUser>();

            Assembly server = Assembly.Load("Logistics.DAL");//获取你实现类的命名空间

            builder.RegisterAssemblyTypes(server)
                .AsImplementedInterfaces()
                .InstancePerDependency();       //实现批量注入
        }
    }
}
