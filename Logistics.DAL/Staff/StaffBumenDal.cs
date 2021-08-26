using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.MODEL.Staff;
using Logistics.Common;
using Logistics.IDAL.IStaff;

namespace Logistics.DAL.Staff
{
    public class StaffBumenDal : DapperHelper<StaffBumen>, IStaffBumen
    {
        public List<StaffBumen> GetBumen(int id)
        {
            string sql = $"select * from StaffBumen where BumenZid = {id}";

            List<StaffBumen> data = QueryCha(sql);

            return data;
        }
    }
}
