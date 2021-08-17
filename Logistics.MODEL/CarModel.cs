using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.MODEL
{
    public class CarModel
    {
        public int CarId			 { get; set; }
        public string CarType			 { get; set; }
        public string CarNumber		 { get; set; }
        public string CarUserName		 { get; set; }
        public string CarCompany		 { get; set; }
        public string CarSize			 { get; set; }
        public string CarColor		 { get; set; }
        public DateTime CarCreateTime	 { get; set; }
        public string CarYunNumber	 { get; set; }
        public DateTime CarBaoEneTime	 { get; set; }
        public DateTime CarEndTime		 { get; set; }
        public int CarKG			 { get; set; }
        public string CarImg			 { get; set; }
        public string CarBaoImg { get; set; }
    }
}
