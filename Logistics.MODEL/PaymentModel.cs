using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.MODEL
{
    public class PaymentModel
    {
        public int PaymentId			 { get; set; }
        public string Paymenttitle		 { get; set; }
        public string Paymentfrom			 { get; set; }
        public int Paymentprice		 { get; set; }
        public string Paymenttype			 { get; set; }
        public string Paymentobj			 { get; set; }
        public string Paymentnumber		 { get; set; }
        public string Paymenter			 { get; set; }
        public DateTime Paymentdate			 { get; set; }
        public string Paymentbei			 { get; set; }
        public DateTime Paymentcreatetime	 { get; set; }
        public int Paymentzhuang		 { get; set; }
        public string Paymentpiren { get; set; }
    }
}
