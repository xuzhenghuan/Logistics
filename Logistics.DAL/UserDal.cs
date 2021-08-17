using System;
using System.Collections.Generic;
using Logistics.IDAL;
using Dapper;
using System.Data.SqlClient;
using Logistics.Common;
using Logistics.MODEL;
using System.Linq;

namespace Logistics.DAL
{
    public class UserDal : IUser
    {
        SqlConnection conn = new SqlConnection(Connection.MSSql);
        
        public string Login(UserModel m,string sql)
        {
            //参数化
            var par = new { @a = m.UserName, @b = m.UserPwd };

            //执行查询语句
            UserModel data = conn.Query<UserModel>(sql,par).FirstOrDefault();//多的该用户的权限信息

            if(data==null)
            {
                return "0";//表示查询不到改账号信息
            }

            return data.UserRoles;//返回角色信息
        }
        
    }
}
