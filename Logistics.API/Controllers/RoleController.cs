using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logistics.IDAL;
using Microsoft.AspNetCore.Authorization;
using Logistics.Common.Filter;
using Logistics.MODEL.Log4;

namespace Logistics.API.Controllers
{
    /// <summary>
    /// 角色API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RoleController : ControllerBase
    {
        private IRole role;
        public RoleController(IRole _role)
        {
            role = _role;
        }

        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <param name="id">角色id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetRole")]
        public string GetRole(string id)
        {
            string sql = "select * from Roles where RoleId = @id";//根据角色id查询

            string ids = role.GetRoles(id, sql);

            return ids;
        }
    }
}
