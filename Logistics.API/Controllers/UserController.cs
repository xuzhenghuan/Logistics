using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logistics.IDAL;
using Logistics.DAL;
using Logistics.MODEL;

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
        //构造函数注入
        public UserController(IUser _user)
        {
            user = _user;
        }

        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="m">账号密码</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public string Login(UserModel m)
        {
            string sql = "select UserRoles from Users where UserName = @a and UserPwd = @b";

            //调用userdal方法实现查询用户
            string roles = user.Login(m, sql);

            //返回该用户对应的角色
            return roles;
        }
        
    }
}
