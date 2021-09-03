using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logistics.MODEL;
using System.Threading.Tasks;

namespace Logistics.IDAL
{
    public interface IInvoice
    {
        List<InvoiceModel> GetInvoice(string name);

        int DelInvoice(int id);

        int AddInvoice(InvoiceModel m);

        InvoiceModel GetInvoiceInfo(int id);

        int UpdateInvoice(InvoiceModel m);
    }
}
