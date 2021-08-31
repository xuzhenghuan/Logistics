using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.MODEL.Staff;

namespace Logistics.IDAL.IStaff
{
    public interface IStaffHired
    {
        //入职员工查询
        public List<StaffHired> GetRuStaffInfo();
        //添加入职员工信息
        public int AddHiredStaff(StaffHired m);

        public StaffHired GetStaffHiredInfo(int Htid);
    }
}
