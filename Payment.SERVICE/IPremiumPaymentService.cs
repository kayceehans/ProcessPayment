using Payment.MODEL;
using Payment.RESPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.SERVICE
{
    public interface IPremiumPaymentService
    {
        ReturnObject PayOut(PaymentModel payment);
    }
}
