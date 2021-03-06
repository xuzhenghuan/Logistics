using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logistics.MODEL;
using Logistics.DAL;
using Logistics.IDAL;

namespace Logistics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BargainController : ControllerBase
    {
        private readonly IShipperBargain bar;
        
        public BargainController(IShipperBargain _bar,ICharge _cha)
        {
            this.bar = _bar;
            
        }

        /// <summary>
        /// 获取货主合同信息
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("GetShipperBargain")]
        public IActionResult GetShipperBargain(string name)
        {
            name += "";
            List<ShipperBargainModel> data = bar.GetShipperBargain(name);
            return Ok(new { data = data, message = "查询成功" });
        }

        /// <summary>
        /// 删除货主合同信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost,Route("ShipperBarDel")]
        public IActionResult ShipperBarDel(int id)
        {
            int count = bar.DelShipperBargain(id);
            return Ok(new { code = count, message = "执行完毕" });
        }

        /// <summary>
        /// 货主添加
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost,Route("AddShipperBargain")]
        public IActionResult AddShipperBargain(ShipperBargainModel m)
        {
            int count = bar.AddShipperBargain(m);
            return Ok(new { code = count, message = "成功执行" });
        }

        /// <summary>
        /// 货主信息查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, Route("GetShipperInfo")]
        public IActionResult GetShipperInfo(int id)
        {
            ShipperBargainModel data = bar.GetShipperInfo(id);
            return Ok(new { data = data, message = "执行成功" });
        }

        /// <summary>
        /// 修改货主信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost,Route("UpdateShipperBargain")]
        public IActionResult UpdateShipperBargain(ShipperBargainModel m)
        {
            int count = bar.UpdateShipper(m);
            return Ok(new { code = count, message = "执行成功" });
        }
    }
}
