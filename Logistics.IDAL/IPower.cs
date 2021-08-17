using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.MODEL;

namespace Logistics.IDAL
{
    public interface IPower
    {
        List<PowerModel> GetPower(string id, string sql);

        List<PowerModel> GetBody(int id, string sql);
    }
}
