using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.MODEL;

namespace Logistics.IDAL
{
    public interface ICar
    {
        List<CarModel> GetCarInfo(out int count, string carType = "", string carNumber = "", string userName = "", string company = "", int pageIndex = 1, int size = 3);

        //添加车辆
        int InsertCar(CarModel m);

        //删除
        int DeleteCar(string id);

        //编辑、查看
        CarModel UpdateCar(int id);

        //修改
        int UpdateCarInfo(CarModel m);
    }
}
