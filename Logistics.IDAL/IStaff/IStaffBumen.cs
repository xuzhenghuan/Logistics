using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.MODEL.Staff;

namespace Logistics.IDAL.IStaff
{
    public interface IStaffBumen
    {
        //获取部门信息
        List<StaffBumen> GetBumen(int id);
    }
}
