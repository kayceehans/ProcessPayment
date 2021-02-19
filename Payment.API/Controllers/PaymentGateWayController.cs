using Microsoft.AspNetCore.Mvc;
using Payment.API.Helper;
using Payment.API.ViewModel;
using Payment.ENUM;
using Payment.MODEL;
using Payment.RESPOSITORY;
using Payment.SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentGateWayController : Controller
    {
        private readonly UnitOfWork _unitofwork;
        private readonly IGateWayChoiceMaker _gatewaypay;
        public PaymentGateWayController(UnitOfWork unitofwork, IGateWayChoiceMaker gatewaypay)
        {
            _unitofwork = unitofwork;
            _gatewaypay = gatewaypay;
        }

        
        [HttpPost]
        public ReturnObject ProcessPayment(PaymentModel payment)
        {
            var processPayment = _gatewaypay.ProcessPay(payment);

            if (processPayment.Status)
            {
                _unitofwork.PaymentRepository.Insert(new PaymentModel
                {
                    Amount = payment.Amount,
                    SecuirtyCode = payment.SecuirtyCode,
                    PaymentState = (int)PaymentStateEnum.Processed,
                    CardHolder = payment.CardHolder,
                    CreditCardNumber = payment.CreditCardNumber,
                    ExpirationDate = payment.ExpirationDate,
                });

                _unitofwork.Save();
                _unitofwork.Dispose();

                return processPayment;
            }

            _unitofwork.PaymentRepository.Insert(new PaymentModel
            {
                Amount = payment.Amount,
                SecuirtyCode = payment.SecuirtyCode,
                PaymentState = (int)PaymentStateEnum.Failed,
                CardHolder = payment.CardHolder,
                CreditCardNumber = payment.CreditCardNumber,
                ExpirationDate = payment.ExpirationDate,
            });

            _unitofwork.Save();
            _unitofwork.Dispose();
            return processPayment;
        }
    }
}
