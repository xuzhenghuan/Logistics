using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.MODEL
{
    public class ChargeModel
    {
        public int ChargeId		 { get; set; }
        public string ChargeNumber	 { get; set; }
        public string ChargeCompany	 { get; set; }
        public string ChargeType		 { get; set; }
        public string ChargeDunwei	 { get; set; }
        public double ChargePrice		 { get; set; }
        public int ChargeMoney		 { get; set; }
        public DateTime ChargeDate		 { get; set; }
        public string ChargeWomen		 { get; set; }
        public DateTime ChargeCreatedate { get; set; }
        public string ChargeBei		 { get; set; }
        public int ChargeZhuang	 { get; set; }
        public string ChargeRen		 { get; set; }
        public DateTime ChargeHedate { get; set; }
    }
}
