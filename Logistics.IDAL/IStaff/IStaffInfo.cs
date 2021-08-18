using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.MODEL.Staff;

namespace Logistics.IDAL.Istaff
{
    public interface IStaffInfo
    {
        List<StaffViewModel> GetStaInfo();

        //新增
        int AddStaInfoOrBumen(StaffInfo m);
    }
}
