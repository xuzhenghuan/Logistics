using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logistics.DAL;
using Logistics.IDAL;
using Logistics.MODEL;

namespace Logistics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChargainController : ControllerBase
    {
        private readonly ICharge cha;
        private readonly IInvoice iiv;
        public ChargainController(ICharge _cha,IInvoice _iiv)
        {
            this.cha = _cha;
            this.iiv = _iiv;
        }
        /// <summary>
        /// 应收费显示
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetCharge")]
        public IActionResult GetCharge()
        {
            List<ChargeModel> data = cha.GetCharge();
            return Ok(new { data = data, message = "查询成功" });
        }

        /// <summary>
        /// 应收费添加
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost, Route("AddCharge")]
        public IActionResult AddCharge(ChargeModel m)
        {
            int count = cha.AddCharge(m);
            return Ok(new { code = count, message = "执行成功" });
        }

        /// <summary>
        /// 应收费删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, Route("DelCharge")]
        public IActionResult DelCharge(int id)
        {
            int count = cha.DelCharge(id);
            return Ok(new { code = count, message = "执行成功" });
        }

        /// <summary>
        /// 应收费信息获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost,Route("GetChargeInfo")]
        public IActionResult GetChargeInfo(int id)
        {
            ChargeModel data = cha.GetChargeInfo(id);
            return Ok(new { data = data, message = "执行成功" });
        }

        /// <summary>
        /// 修改应收费
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost,Route("UpdateChargein")]
        public IActionResult UpdateChargein(ChargeModel m)
        {
            int count = cha.UpdateChargain(m);
            return Ok(new { code = count, message = "执行成功" });
        }



        /// <summary>
        /// 进项发票查询
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetInvoice")]
        public IActionResult GetInvoice(string name)
        {
            name += "";
            List<InvoiceModel> data = iiv.GetInvoice(name);
            return Ok(new { data = data, message = "查询成功" });
        }

        /// <summary>
        /// 进项发票添加
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost, Route("AddInvoice")]
        public IActionResult AddInvoice(InvoiceModel m)
        {
            int count = iiv.AddInvoice(m);
            return Ok(new { code = count, message = "执行成功" });
        }

        /// <summary>
        /// 进项发票删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, Route("DelInvoice")]
        public IActionResult DelInvoice(int id)
        {
            int count = iiv.DelInvoice(id);
            return Ok(new { code = count, message = "执行成功" });
        }

        /// <summary>
        /// 进项发票信息获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, Route("GetInvoiceInfo")]
        public IActionResult GetInvoiceInfo(int id)
        {
            InvoiceModel data = iiv.GetInvoiceInfo(id);
            return Ok(new { data = data, message = "执行成功" });
        }

        /// <summary>
        /// 进项发票收费
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost, Route("UpdateInvoice")]
        public IActionResult UpdateInvoice(InvoiceModel m)
        {
            int count = iiv.UpdateInvoice(m);
            return Ok(new { code = count, message = "执行成功" });
        }



        /// <summary>
        /// 销项发票查询
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetInvoiceTwo")]
        public IActionResult GetInvoiceTwo(string name)
        {
            name += "";
            List<InvoiceModel> data = iiv.GetInvoice(name);
            return Ok(new { data = data, message = "查询成功" });
        }

        /// <summary>
        /// 销项发票添加
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost, Route("AddInvoiceTwo")]
        public IActionResult AddInvoiceTwo(InvoiceModel m)
        {
            int count = iiv.AddInvoice(m);
            return Ok(new { code = count, message = "执行成功" });
        }

        /// <summary>
        /// 销项发票删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, Route("DelInvoiceTwo")]
        public IActionResult DelInvoiceTwo(int id)
        {
            int count = iiv.DelInvoice(id);
            return Ok(new { code = count, message = "执行成功" });
        }

        /// <summary>
        /// 销项发票信息获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, Route("GetInvoiceInfoTwo")]
        public IActionResult GetInvoiceInfoTwo(int id)
        {
            InvoiceModel data = iiv.GetInvoiceInfo(id);
            return Ok(new { data = data, message = "执行成功" });
        }

        /// <summary>
        /// 销项发票收费
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost, Route("UpdateInvoiceTwo")]
        public IActionResult UpdateInvoiceTwo(InvoiceModel m)
        {
            int count = iiv.UpdateInvoice(m);
            return Ok(new { code = count, message = "执行成功" });
        }
    }
}
