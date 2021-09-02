using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.MODEL
{
    public class ShipperModel
    {
        public int ShipperId		 { get; set; }
        public string ShipperName		 { get; set; }
        public string ShipperPhone	 { get; set; }
        public string ShipperCompany	 { get; set; }
        public string ShipperDate		 { get; set; }
        public string ShipperImg		 { get; set; }
        public string ShipperBei		 { get; set; }
        public DateTime ShipperCreateDate { get; set; }
    }
}
