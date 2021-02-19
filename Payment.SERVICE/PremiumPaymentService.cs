using Payment.MODEL;
using Payment.RESPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.SERVICE
{
    public class PremiumPaymentService : IPremiumPaymentService
    {
        public ReturnObject PayOut(PaymentModel payment)
        {
            
            string transaction = "success or fails";
            if (transaction=="success")
            {
                return new ReturnObject { StatusMessage = "Payment is processed: 200 OK", Data = "Payment details sent", Status = true };
            }
            else
            {
                return new ReturnObject { StatusMessage = "The request is invalid: 400 bad request", Data = "Payment fails", Status = false };
            }
            
        }
    }
}
