using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.MODEL
{
    public class InvoiceModel
    {
        public int InvoiceId		 { get; set; }
        public string InvoiceNumber	 { get; set; }
        public string InvoiceCompany	 { get; set; }
        public string InvoiceType		 { get; set; }
        public int InvoicePrice	 { get; set; }
        public int InvoiceShui		 { get; set; }
        public int InvoiceE		 { get; set; }
        public DateTime Invoicedate		 { get; set; }
        public string InvoiceBei		 { get; set; }
        public string InvoiceCreater	 { get; set; }
        public DateTime InvoiceCreateDate { get; set; }
    }
}
