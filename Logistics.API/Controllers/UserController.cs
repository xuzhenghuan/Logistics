using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logistics.IDAL;
using Logistics.DAL;
using Logistics.MODEL;
using Microsoft.Extensions.Logging;

namespace Logistics.API.Controllers
{
    /// <summary>
    /// 用户API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUser user;
        ILogger<UserController> logger;
        //构造函数注入
        public UserController(IUser _user, ILogger<UserController> _logger)
        {
            user = _user;
            logger = _logger;//注入nlog的服务
        }

        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="m">账号密码</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(UserModel m)
        {
            string sql = "select * from Users where UserName = @a and UserPwd = @b";

            //调用userdal方法实现查询用户
            UserModel roles = user.Login(m, sql);

            if(roles==null)
            {
                logger.LogInformation($"用户名{m.UserName}于{DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss")}登录失败");//生成一个登录失败的日志
                return Ok(new { data = 0 });
            }

            logger.LogInformation($"用户名{m.UserName}于{DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss")}登陆成功");//生成一个登录失败的日志
            //返回该用户对应的角色
            return Ok(new { data = roles });

        }
    }
}
