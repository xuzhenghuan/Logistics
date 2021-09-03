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
    public class PaymentDal : DapperHelper<PaymentModel>, IPayment
    {
        public int AddPayment(PaymentModel m)
        {
            string sql = "insert into Payment values(@Paymenttitle,@Paymentfrom,@Paymentprice,@Paymenttype,@Paymentobj,@Paymentnumber,@Paymenter,@Paymentdate,@Paymentbei,@Paymentcreatetime,@Paymentzhuang,@Paymentpiren)";

            int count = Command(sql, m);
            return count;
        }

        public int DelPayment(int id)
        {
            string sql = "delete from Payment where PaymentId = @id";
            int count = CommandDel(sql, new { @id = id });
            return count;
        }

        public List<PaymentModel> GetPayment(string name)
        {
            string sql = $"select * from Payment where Paymenttitle like '%{name}%'";
            List<PaymentModel> data = QueryCha(sql);
            return data;
        }

        public PaymentModel GetPaymentInfo(int id)
        {
            string sql = "select * from Payment where PaymentId = @id";

            PaymentModel data = GetInfo_Id(sql, new { @id = id });

            return data;
        }

        public int UpdatePayment(PaymentModel m)
        {
            string sql = "update Payment set Paymenttitle=@Paymenttitle,Paymentfrom=@Paymentfrom,Paymentprice=@Paymentprice,Paymenttype=@Paymenttype,Paymentobj=@Paymentobj,Paymentnumber=@Paymentnumber,Paymenter=@Paymenter,Paymentdate=@Paymentdate,Paymentbei=@Paymentbei,Paymentcreatetime=@Paymentcreatetime,Paymentzhuang=@Paymentzhuang,Paymentzhuang=@Paymentzhuang,Paymentpiren=@Paymentpiren where PaymentId=@PaymentId";

            int count = Command(sql, m);
            return count;
        }
    }
}
