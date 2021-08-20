using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logistics.IDAL;
using Logistics.MODEL;
using Microsoft.AspNetCore.Authorization;

namespace Logistics.API.Controllers
{
    /// <summary>
    /// 权限API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PowerController : ControllerBase
    {
        IPower power;
        /// <summary>
        /// 权限注入
        /// </summary>
        /// <param name="_power"></param>
        public PowerController(IPower _power)
        {
            power = _power;
        }

        //获取用户权限
        /// <summary>
        /// 获取角色权限id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetPowers")]
        public List<PowerModel> GetPowers(string id)
        {
            string sql = $"select * from Powers where PowerId in ({id})";//根据角色id查询对应的功能

            List<PowerModel> data = power.GetPower(id, sql);

            return data;
        }


        /// <summary>
        /// 权限下的小菜单
        /// </summary>
        /// <param name="id">权限id</param>
        /// <returns></returns>
        [Route("GetBody")]
        [HttpPost]
        //获取权限的二级菜单
        public List<PowerModel> GetBody(int id)
        {
            string sql = "select * from Powers where PowerZId = @id";

            List<PowerModel> data = power.GetBody(id, sql);
            return data;
        }
    }
}
