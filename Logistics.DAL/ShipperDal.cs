using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.MODEL;
using Logistics.IDAL;
using Logistics.Common;

namespace Logistics.DAL
{
    public class ShipperDal : DapperHelper<ShipperModel>, IShipper
    {
        public int DelShipper(int id)
        {
            string sql = "delete from Shipper where ShipperId = @id";
            int count = CommandDel(sql, new { @id = id });
            return count;
        }

        public List<ShipperModel> GetShipper()
        {
            return QueryCha("select * from Shipper");
        }

        public ShipperModel GetShipperInfo(int id)
        {
            string sql = "select * from Shipper where ShipperId = @id";

            ShipperModel data = GetInfo_Id(sql, new { @id = id });

            return data;
        }
    }
}
