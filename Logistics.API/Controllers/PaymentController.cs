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
    public class PaymentController : ControllerBase
    {
        private readonly IPayment pay;

        public PaymentController(IPayment _pay)
        {
            this.pay = _pay;

        }

        /// <summary>
        /// 付款信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetPayment")]
        public IActionResult GetPayment(string name)
        {
            name += "";
            List<PaymentModel> data = pay.GetPayment(name);
            return Ok(new { data = data, message = "查询成功" });
        }

        /// <summary>
        /// 删除付款信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, Route("PaymentDel")]
        public IActionResult PaymentBarDel(int id)
        {
            int count = pay.DelPayment(id);
            return Ok(new { code = count, message = "执行完毕" });
        }

        /// <summary>
        /// 付款添加
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost, Route("AddPayment")]
        public IActionResult AddPayment(PaymentModel m)
        {
            int count = pay.AddPayment(m);
            return Ok(new { code = count, message = "成功执行" });
        }

        /// <summary>
        /// 付款查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, Route("GetPaymentInfo")]
        public IActionResult GetPaymentInfo(int id)
        {
            PaymentModel data = pay.GetPaymentInfo(id);
            return Ok(new { data = data, message = "执行成功" });
        }

        /// <summary>
        /// 付款信息详细
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost, Route("UpdatePayment")]
        public IActionResult UpdatePayment(PaymentModel m)
        {
            int count = pay.UpdatePayment(m);
            return Ok(new { code = count, message = "执行成功" });
        }
    }
}
