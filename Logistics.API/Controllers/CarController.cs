using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logistics.MODEL;
using Logistics.IDAL;
using Microsoft.AspNetCore.Authorization;

namespace Logistics.API.Controllers
{
    /// <summary>
    /// 车辆管理API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarController : ControllerBase
    {
        ICar car;
        public CarController(ICar _car)
        {
            car = _car;
        }


        /// <summary>
        /// 车辆查询
        /// </summary>
        /// <param name="carType">厂牌型号</param>
        /// <param name="carNumber">车牌号</param>
        /// <param name="userName">司机姓名</param>
        /// <param name="company">所属</param>
        /// <param name="pageIndex">索引页</param>
        /// <param name="size">每页显示数量</param>
        /// <returns></returns>
        [Route("GetCarInfo")]
        [HttpGet]
        //查询
        public IActionResult GetCarInfo(string carType, string carNumber, string userName, string company,int pageIndex = 1, int size = 4)
        {
            int count;

            List<CarModel> data = car.GetCarInfo(out count,carType,carNumber,userName,company,pageIndex,size);
            return Ok(data);
        }

        /// <summary>
        /// 添加车辆
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        //添加车辆
       
        [Route("Insert")]
        [HttpPost]
        public IActionResult Insert(CarModel m)
        {
            int count = car.InsertCar(m);
            return Ok(count);
        }

        /// <summary>
        /// 车辆删除
        /// </summary>
        /// <param name="id">id可多个</param>
        /// <returns></returns>
        [HttpPost,Route("DeleteCar")]
        //删除车辆
        public IActionResult DeleteCar(string id)
        {
            //调用delete方法
            int count = car.DeleteCar(id);

            return Ok(count);
        }

        /// <summary>
        /// 车辆编辑、查看
        /// </summary>
        /// <param name="id">车辆的id</param>
        /// <returns></returns>
        [HttpPost,Route("UpdateCar")]
        public IActionResult UpdateCar(int id)
        {
            CarModel data = car.UpdateCar(id);
            return Ok(data);
        }

        /// <summary>
        /// 修改车辆信息
        /// </summary>
        /// <param name="m">对象</param>
        /// <returns></returns>
        [HttpPost,Route("UpdateCarInfo")]
        public IActionResult UpdateCarInfo(CarModel m)
        {
            int count = car.UpdateCarInfo(m);//调用updatecarinfo方法
            if(count>0)//判断结果
            {
                return Ok(new { code = 1, message = "修改成功" });
            }
            return Ok(new { code = 0, message = "修改失败" });
        }
    }
}
