using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.IDAL.Istaff;
using Logistics.MODEL.Staff;
using Logistics.Common;

namespace Logistics.DAL.Staff
{
    public class StaffInfoDal : DapperHelper<StaffViewModel>,IStaffInfo
    {
        //查询部门员工
        public List<StaffViewModel> GetStaInfo()
        {
            string sql = "select a.InfoName,a.InfoSex,c.BumenName,b.BumenName as Bumendeng,a.InfoPhone,a.InfoSchool,a.InfoZhuan,a.InfoHome,a.InfoCreateTime,a.InfoAge,a.InfoType,a.InfoZhuang,a.InfoUpdate from StaffInfo a  join StaffBumen b on a.ZhiweiIdFor = b.BumenId join StaffBumen c on a.BumenIdFor = c.BumenId";

            List<StaffViewModel> data = QueryCha(sql);
            return data;
        }

        //新增部门、员工
        public int AddStaInfoOrBumen(StaffInfo m)
        {
            string sql = "insert into StaffInfo values(@InfoName,@InfoSex ,@InfoPhone,@InfoSchool,@InfoZhuan,@InfoHome,@InfoCreateTime,@InfoAge,@InfoXueli,@InfoZheng,@InfoMin,@InfoJi,@InfoHun,@InfoUpdate,@InfoEmail,@InfoInfo,@BumenIdFor,@ZhiweiIdFor,@InfoType,0)";

            //var par = new
            //{
            //    @InfoName=m.InfoName,
            //    @InfoSex=m.InfoSex,
            //    @InfoPhone=m.InfoPhone,
            //    @InfoSchool=m.InfoSchool,
            //    @InfoZhuan=m.InfoSchool,
            //    @InfoHome=m.InfoHome,
            //    @InfoCreateTime=m.InfoCreateTime,
            //    @InfoAge=1,
            //    @InfoXueli=m.InfoXueli,
            //    @InfoZheng=m.
            //}
            int count = Command(sql,m);
            return count;
        }
    }
}
