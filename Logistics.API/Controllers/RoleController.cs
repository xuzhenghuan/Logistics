using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logistics.IDAL;

namespace Logistics.API.Controllers
{
    /// <summary>
    /// 角色API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
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
