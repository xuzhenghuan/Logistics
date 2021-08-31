using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace Logistics.Common
{
    public class DapperHelper<T> where T:class,new()
    {
        SqlConnection conn = new SqlConnection(Connection.MSSql);//链接字符串

        public int Command(string sql,Object zhi)
        {
            int count = conn.Execute(sql,zhi);
            return count;
        }

        //查询
        public List<T> QueryCha(string sql)
        {
            List<T> data = conn.Query<T>(sql).ToList();
            return data;
        }
        //删除
        public int CommandDel(string sql,int id)
        {
            int count = conn.Execute(sql, new { @id=id });
            return count;
        }
        //详情
        public T GetInfo_Id(string sql,int HtId)
        {
            T data = conn.Query<T>(sql, new { @HtId=HtId }).SingleOrDefault();

            return data;
        }
    }
}
