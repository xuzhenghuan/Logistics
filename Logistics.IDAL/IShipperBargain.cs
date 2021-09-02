using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.MODEL;

namespace Logistics.IDAL
{
    public interface IShipperBargain
    {
        List<ShipperBargainModel> GetShipperBargain();

        int DelShipperBargain(int id);

        int AddShipperBargain(ShipperBargainModel m);

        ShipperBargainModel GetShipperInfo(int id);

        int UpdateShipper(ShipperBargainModel m);
    }
}
