using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.MODEL;

namespace Logistics.IDAL
{
    public interface ICharge
    {
        /// <summary>
        /// 应收费查询
        /// </summary>
        /// <returns></returns>
        List<ChargeModel> GetCharge();

        int DelCharge(int id);

        int AddCharge(ChargeModel m);
    }
}
