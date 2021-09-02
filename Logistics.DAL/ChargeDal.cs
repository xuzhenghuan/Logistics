using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.Common;
using Logistics.IDAL;
using Logistics.MODEL;

namespace Logistics.DAL
{
    public class ChargeDal : DapperHelper<ChargeModel>, ICharge
    {
        public int AddCharge(ChargeModel m)
        {
            string sql = "insert into ChargeTable values(@ChargeNumber,@ChargeCompany,@ChargeType,@ChargeDunwei,@ChargePrice,@ChargeMoney,@ChargeDate,@ChargeWomen,@ChargeCreatedate,'-',@ChargeZhuang,@ChargeRen,@ChargeHedate)";

            int count = Command(sql, m);
            return count;
        }

        public int DelCharge(int id)
        {
            string sql = "delete from ChargeTable where ChargeId = @id";
            int count = Command(sql, new { @id = id });
            return count;
        }
        /// <summary>
        /// 获取应收费信息
        /// </summary>
        /// <returns></returns>

        public List<ChargeModel> GetCharge()
        {
            string sql = "select * from chargetable";

            List<ChargeModel> data = QueryCha(sql);

            return data;
        }
    }
}
