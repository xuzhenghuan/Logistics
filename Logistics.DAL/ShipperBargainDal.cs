using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.Common;
using Logistics.IDAL;
using Logistics.MODEL;

namespace Logistics.DAL
{
    public class ShipperBargainDal : DapperHelper<ShipperBargainModel>, IShipperBargain
    {
        public int AddShipperBargain(ShipperBargainModel m)
        {
            string sql = "insert into ShipperBargain values(@SBbian,@SBtitle,@SBcompany,@SBshipper,@SBxian,@SBdun,@SBdunwei,@SBprice,@SBdate,@SBren,@SCcreatedate,@SCzhuang,'-')";

            int count = Command(sql, m);
            return count;
        }

        public int DelShipperBargain(int id)
        {
            string sql = "delete from ShipperBargain where SBid = @id";
            int count = CommandDel(sql, new { @id = id });
            return count;
        }

        public List<ShipperBargainModel> GetShipperBargain()
        {
            string sql = "select * from ShipperBargain";
            List<ShipperBargainModel> data = QueryCha(sql);
            return data;
        }

        public ShipperBargainModel GetShipperInfo(int id)
        {
            string sql = "select * from ShipperBargain where SBId = @id";

            ShipperBargainModel data = GetInfo_Id(sql, new { @id = id });

            return data;
        }

        public int UpdateShipper(ShipperBargainModel m)
        {
            string sql = "update ShipperBargain set SBbian=@SBbian,SBtitle=@SBtitle,SBcompany=@SBcompany,SBshipper=@SBshipper,SBxian=@SBxian,SBdun=@SBdun,SBdunwei=@SBdunwei,SBprice=@SBprice,SBdate=@SBdate,SBren=@SBren,SCcreatedate=@SCcreatedate,SCzhuang=@SCzhuang,SCshen=@SCshen where SBid=@SBid";

            int count = Command(sql, m);
            return count;
        }
    }
}
