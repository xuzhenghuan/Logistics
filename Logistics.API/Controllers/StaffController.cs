using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logistics.MODEL.Staff;
using Logistics.IDAL.Istaff;

namespace Logistics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        public IStaffInfo sta;
        public StaffController(IStaffInfo _sta)
        {
            sta = _sta;
        }

        /// <summary>
        /// 员工登记查询
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("GetStaff")]
        public IActionResult GetStaff()
        {
            List<StaffViewModel> data = sta.GetStaInfo();
            return Ok(data);
        }

        /// <summary>
        /// 添加
        /// </summary>
        [HttpPost,Route("")]
        public IActionResult AddStaffInfo(StaffInfo m)
        {
            int count = sta.AddStaInfoOrBumen(m);

            if(count>0)
            {
                return Ok(new { code = 200, message = "添加成功" });
            }
            return Ok(new { code = 201, message = "添加失败" });
        }
    }
}
