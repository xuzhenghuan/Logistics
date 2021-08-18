using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.MODEL.Staff
{
    public class StaffInfo
    {
        public int InfoId			 { get; set; }
        public string InfoName		 { get; set; }
        public int InfoSex			 { get; set; }
        public string InfoPhone		 { get; set; }
        public string InfoSchool		 { get; set; }
        public string InfoZhuan		 { get; set; }
        public string InfoHome		 { get; set; }
        public DateTime InfoCreateTime { get; set; }
        public int InfoAge			 { get; set; }
        public string InfoXueli		 { get; set; }
        public string InfoZheng		 { get; set; }
        public string InfoMin			 { get; set; }
        public string InfoJi			 { get; set; }
        public string InfoHun			 { get; set; }
        public DateTime InfoUpdate		 { get; set; }
        public string InfoEmail		 { get; set; }
        public string InfoInfo		 { get; set; }
        public int BumenIdFor		 { get; set; }
        public int ZhiweiIdFor		 { get; set; }
        public string InfoType { get; set; }
        public int InfoZhuang { get; set; }
    }
}
