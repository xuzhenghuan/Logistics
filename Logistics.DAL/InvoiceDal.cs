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
    class InvoiceDal : DapperHelper<InvoiceModel>, IInvoice
    {
        public int AddInvoice(InvoiceModel m)
        {
            string sql = "insert into Invoice values(@InvoiceNumber,@InvoiceCompany,@InvoiceType,@InvoicePrice,@InvoiceShui,@InvoiceE,@Invoicedate,@InvoiceBei,@InvoiceCreater,@InvoiceCreateDate)";

            int count = Command(sql, m);
            return count;
        }

        public int DelInvoice(int id)
        {
            string sql = "delete from Invoice where InvoiceId = @id";
            int count = CommandDel(sql, new { @id = id });
            return count;
        }

        public List<InvoiceModel> GetInvoice(string name)
        {
            string sql = $"select * from Invoice where InvoiceNumber like '%{name}%'";
            List<InvoiceModel> data = QueryCha(sql);
            return data;
        }

        public InvoiceModel GetInvoiceInfo(int id)
        {
            string sql = "select * from Invoice where InvoiceId = @id";

            InvoiceModel data = GetInfo_Id(sql, new { @id = id });

            return data;
        }

        public int UpdateInvoice(InvoiceModel m)
        {
            string sql = "update ShipperBargain set InvoiceNumber=@InvoiceNumber,InvoiceCompany=@InvoiceCompany,InvoiceType=@InvoiceType,InvoicePrice=@InvoicePrice,InvoiceShui=@InvoiceShui,InvoiceE=@InvoiceE,Invoicedate=@Invoicedate,InvoiceBei=@InvoiceBei,InvoiceCreater=@InvoiceCreater,InvoiceCreateDate=@InvoiceCreateDate where InvoiceId=@InvoiceId";

            int count = Command(sql, m);
            return count;
        }
    }
}
