using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Logistics.IDAL;
using Logistics.MODEL;
using System.Data.SqlClient;
using System.Data;
using Logistics.Common;

namespace Logistics.DAL
{
    public class CarDal : ICar
    {

        IDbConnection conn = new SqlConnection(Connection.MSSql);

        //分页查询数据
        public List<CarModel> GetCarInfo(out int count, string carType, string carNumber,string userName, string company, int pageIndex, int size)
        {
            carNumber += "";
            carType += "";
            userName += "";
            company += "";
            string ex = "exec sp_SelectCar @type,@number,@name,@company,@index,@size,@carcount out";

            DynamicParameters par = new DynamicParameters();
            par.Add("@type", carType);
            par.Add("@number", carNumber);
            par.Add("@name", userName);
            par.Add("@company", company);
            par.Add("@index", pageIndex);
            par.Add("@size", size);
            par.Add("@carcount",null,dbType:DbType.Int32, direction: ParameterDirection.Output);
            
            List<CarModel> data = conn.Query<CarModel>(ex, par).ToList();

            count = par.Get<int>("@carcount");//获取输出参数的值

            return data;
        }

        //添加
        public int InsertCar(CarModel m)
        {
            string sql = $"insert into CarManage values('{m.CarType}', '{m.CarNumber}', '{m.CarUserName}', '{m.CarCompany}', '{m.CarSize}', '{m.CarColor}', '{(m.CarCreateTime).ToString("yyyy-MM-dd")}', '{m.CarYunNumber}', '{(m.CarBaoEneTime).ToString("yyyy-MM-dd")}', '{(m.CarEndTime).ToString("yyyy-MM-dd")}', {m.CarKG}, null, null)";

            //执行添加
            int count = conn.Execute(sql);
            return count;
        }

        //删除
        public int DeleteCar(string id)
        {

            

            int count = -1;

            if (id == null)
            {
                return count;
            }

            string sql = "delete from CarManage where CarId in (@id)";//sql语句

            string[] ids = id.Split(',');//根据，隔开

            //循环id
            foreach (string item in ids)
            {
                var par = new { @id = Convert.ToInt32(item) };//转为int类型

                count = conn.Execute(sql, par);//执行
            }
            

            return count;
        }

        //查看、编辑
        public CarModel UpdateCar(int id)
        {
            string sql = "select * from CarManage where CarId = @id";

            CarModel data = conn.Query<CarModel>(sql, new { @id = id }).FirstOrDefault();//返回第一个对象或者空

            return data;
        }

        //修改
        public int UpdateCarInfo(CarModel m)
        {
            string sql = "update CarManage set CarType=@CarType,CarNumber=@CarNumber,CarUserName=@CarUserName,CarCompany=@CarCompany,CarSize=@CarSize,CarColor=@CarColor,CarCreateTime=@CarCreateTime,CarYunNumber=@CarYunNumber,CarBaoEneTime=@CarBaoEneTime,CarEndTime=@CarEndTime where CarId =@CarId";

            int count = conn.Execute(sql, m);
            return count;
        }
    }
}
