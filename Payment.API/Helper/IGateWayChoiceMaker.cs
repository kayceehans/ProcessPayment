using Payment.MODEL;
using Payment.RESPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.API.Helper
{
    public interface IGateWayChoiceMaker
    {
        ReturnObject ProcessPay(PaymentModel payment);

    }
}
