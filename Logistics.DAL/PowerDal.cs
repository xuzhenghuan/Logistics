using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.IDAL;
using Logistics.MODEL;
using Dapper;
using System.Data.SqlClient;
using Logistics.Common;

namespace Logistics.DAL
{
    public class PowerDal : IPower
    {
        SqlConnection conn = new SqlConnection(Connection.MSSql);
        //获取一级菜单
        public List<PowerModel> GetPower(string id, string sql)
        {

            List<PowerModel> data = conn.Query<PowerModel>(sql).ToList();

            return data;
        }

        //获取二级菜单
        public List<PowerModel> GetBody(int id,string sql)
        {
            var par = new { @id = id };//参数化

            List<PowerModel> data = conn.Query<PowerModel>(sql, par).ToList();//获取对应的下级权限

            return data;
        }
    }
}
