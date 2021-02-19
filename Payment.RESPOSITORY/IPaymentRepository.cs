using Payment.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.RESPOSITORY
{
    public interface IPaymentRepository
    {
       IEnumerable<PaymentModel> GetPayAllPayments();
        PaymentModel GetPayMentByID(int PaymentModelId);
        void InsertPayment(PaymentModel paymentmodel);
        void UpdatePayment(PaymentModel paymentmodel);
        void DeletePaymentByID(int id);
        void Save();
    }
}
