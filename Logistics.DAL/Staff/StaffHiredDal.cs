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
    public class StaffHiredDal:DapperHelper<StaffHired>,IStaffHired
    {
        //入职员工查询
        public List<StaffHired> GetRuStaffInfo()
        {
            string sql = "select * from HiredTable";
            List<StaffHired> data = QueryCha(sql);
            return data;
        }

        //添加入职员工信息
        public int AddHiredStaff(StaffHired m)
        {
            string sql = "insert into HiredTable values(@HtName,@HtBuName,@HtZhiName,@HtUpName,@HtRuTime,@HtCreateTime,0,@HtSheng,@HtStaffInfo)";

            int count = Command(sql, m);
            return count;
        }

        //用户入职详细信息
        public StaffHired GetStaffHiredInfo(int Htid)
        {
            string sql = "select * from HiredTable where HtId = @Htid";
            StaffHired data = GetInfo_Id(sql, Htid);
            return data;
        }
    }
}
