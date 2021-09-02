using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.MODEL;

namespace Logistics.IDAL
{
    public interface IShipper
    {
        List<ShipperModel> GetShipper();

        int DelShipper(int id);

        ShipperModel GetShipperInfo(int id);
    }
}
