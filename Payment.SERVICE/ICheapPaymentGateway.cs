using Payment.MODEL;
using Payment.RESPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payment.SERVICE
{
    public interface ICheapPaymentGateway
    {
        ReturnObject PayOut(PaymentModel payment);
    }
}
