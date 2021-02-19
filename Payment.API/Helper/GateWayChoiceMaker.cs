using Payment.MODEL;
using Payment.RESPOSITORY;
using Payment.SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.API.Helper
{
    public class GateWayChoiceMaker : IGateWayChoiceMaker
    {
        private readonly IExpensivePaymentGateway _expensivepaymentGateway;
        private readonly ICheapPaymentGateway _cheappaymentGateway;
        private readonly IPremiumPaymentService _premiumPay;
        public GateWayChoiceMaker(ICheapPaymentGateway cheappaymentGateway, IExpensivePaymentGateway expensivepaymentGateway, IPremiumPaymentService premiumPay)
        {
            _cheappaymentGateway = cheappaymentGateway;
            _expensivepaymentGateway = expensivepaymentGateway;
            _premiumPay = premiumPay;
        }
        public ReturnObject ProcessPay(PaymentModel payment)
        {
            var PaymentGateway = AssignGateway(payment.Amount);

            ReturnObject paymentResponse = new ReturnObject {Status = false, Data = "", StatusMessage = ""};
            switch (PaymentGateway)
            {
                case "Cheap":
                    paymentResponse = _cheappaymentGateway.PayOut(payment);


                    break;

                case "Expensive":
                    paymentResponse = _expensivepaymentGateway.PayOut(payment);
                    break;

                case "Premium":
                    paymentResponse = _premiumPay.PayOut(payment);
                    break;
            }

            return paymentResponse;
        }

        private static string AssignGateway(decimal amount)
        {
            if (amount < 200)
            {
                return "Cheap";
            }
            else if (amount > 200 || amount <= 500)
            {
                return "Expensive";
            }
            else
            {
                return "Premium";
            }

        }
    }
}
