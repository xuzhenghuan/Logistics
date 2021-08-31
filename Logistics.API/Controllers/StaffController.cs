using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logistics.MODEL.Staff;
using Logistics.IDAL.IStaff;
using Logistics.IDAL.Istaff;
using Microsoft.AspNetCore.Authorization;

namespace Logistics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class StaffController : ControllerBase
    {
        public IStaffInfo sta;//登记
        public IStaffBumen sta2;//部门
        public IStaffHired sta3;//入职
        public StaffController(IStaffInfo _sta,IStaffBumen _st2,IStaffHired _sta3)
        {
            this.sta = _sta;
            this.sta2 = _st2;
            this.sta3 = _sta3;
        }

        /// <summary>
        /// 员工登记查询
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("GetStaff")]
        public IActionResult GetStaff(string name="",string phone="",int page=1,int size=4)
        {
            List<StaffViewModel> data = sta.GetStaInfo(name,phone);

            List<StaffViewModel> newData = (from a in data.Skip((page - 1) * size).Take(size) select a).ToList();
            return Ok(newData);
        }

        /// <summary>
        /// 添加员工登记
        /// </summary>
        [HttpPost,Route("AddStaffInfo")]
        public IActionResult AddStaffInfo(StaffInfo m)
        {
            int count = sta.AddStaInfoOrBumen(m);

            if(count>0)
            {
                return Ok(new { code = 200, message = "添加成功" });
            }
            return Ok(new { code = 201, message = "添加失败" });
        }

        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <param name="id">上级id(默认为0)</param>
        /// <returns></returns>
        [HttpGet,Route("GetBumen")]
        public IActionResult GetBumen(int id=0)
        {
            List<StaffBumen> data = sta2.GetBumen(id);

            var list = data.Select(p => new { value = p.BumenId, label = p.BumenName }).ToList();//利用

            return Ok(list);
        }

        /// <summary>
        /// 员工信息移除
        /// </summary>
        /// <param name="id">员工id</param>
        /// <returns></returns>
        [HttpPost,Route("StaffInfoDel")]
        public IActionResult StaffInfoDel(int id)
        {
            int count = sta.StaffInfoDel(id);
            if(count>0)
            {
                return Ok(new { code = 200, message = "删除成功" });
            }
            return Ok(new { code = 201, message = "删除失败" });
        }

        /// <summary>
        /// 查询已入职的员工
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("GetRuStaffInfo")]
        public IActionResult GetRuStaffInfo()
        {
            List<StaffHired> data = sta3.GetRuStaffInfo();
            return Ok(new { data = data, message = "查询成功" });
        }

        /// <summary>
        /// 添加员工入职信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost,Route("AddHiredStaff")]
        public IActionResult AddHiredStaff(StaffHired m)
        {
            int count = sta3.AddHiredStaff(m);
            if(count>0)
            {
                return Ok(new { code = 200, message = "添加成功" });
            }
            return Ok(new { code = 201, message = "添加失败" });
        }

        /// <summary>
        /// 获取待入职的员工信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet,Route("GetDaiRuStaff")]
        public IActionResult GetDaiRuStaff(int id)
        {
            List<StaffViewModel> data = sta.GetDaiRuStaff(id);
            if(data!=null)
            {
                return Ok(new { data = data, message = "查询成功" });
            }
            return Ok(null);
        }

        /// <summary>
        /// 审批入职员工信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost,Route("GetStaffHired")]
        public IActionResult GetStaffHired(int id)
        {
            StaffHired data = sta3.GetStaffHiredInfo(id);
            if(data!=null)
            {
                return Ok(new { code = 200, message = "查询成功", data = data });
            }
            return Ok(new { code = 201, message = "查询失败" });
        }
    }
}
