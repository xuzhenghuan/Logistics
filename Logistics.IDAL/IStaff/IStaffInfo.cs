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
        List<StaffViewModel> GetStaInfo(string name,string phone);

        //新增
        int AddStaInfoOrBumen(StaffInfo m);

        //删除
        int StaffInfoDel(int id);

        //获取部门、职位所对应的待入职员工
        List<StaffViewModel> GetDaiRuStaff(int ZhiId);
    }
}
