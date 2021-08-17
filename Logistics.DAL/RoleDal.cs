using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logistics.MODEL;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Logistics.IDAL;
using Logistics.Common;

namespace Logistics.DAL
{
    public class RoleDal:IRole
    {
        SqlConnection conn = new SqlConnection(Connection.MSSql);
        //用户定义角色
        public string GetRoles(string roleid, string sql)
        {
            //异常
            try
            {
                string sumRoles = "";

                string sumRoles2 = "";
                var ids = roleid.Split(',');

                foreach (string item in ids)
                {
                    var par = new { @id = item };
                    //执行查询语句
                    RolesModel data = conn.Query<RolesModel>(sql, par).FirstOrDefault();//多的该用户的权限信息

                    sumRoles += ',' + data.RolePower;//把权限id累加起来

                    sumRoles2 = sumRoles.Trim(',');
                }
                return sumRoles2;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
