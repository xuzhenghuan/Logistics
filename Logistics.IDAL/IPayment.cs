using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.MODEL;

namespace Logistics.IDAL
{
    public interface IPayment
    {

        List<PaymentModel> GetPayment(string name);

        int DelPayment(int id);

        int AddPayment(PaymentModel m);

        PaymentModel GetPaymentInfo(int id);

        int UpdatePayment(PaymentModel m);
    }
}
