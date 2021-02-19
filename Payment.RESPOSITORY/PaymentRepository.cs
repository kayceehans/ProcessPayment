using Microsoft.EntityFrameworkCore;
using Payment.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payment.RESPOSITORY
{
   public class PaymentRepository : IPaymentRepository, IDisposable
    {
        private PaymentDbContext context;

        public PaymentRepository(PaymentDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<PaymentModel> GetPayAllPayments()
        {
            return context.PaymentModels.ToList();
        }

        public PaymentModel GetPayMentByID(int id)
        {
            return context.PaymentModels.Find(id);
        }

        public void InsertPayment(PaymentModel student)
        {
            context.PaymentModels.Add(student);
        }

        public void DeletePaymentByID(int id)
        {
            PaymentModel payment = context.PaymentModels.Find(id);
            context.PaymentModels.Remove(payment);
        }

        public void UpdatePayment(PaymentModel payment)
        {
            context.Entry(payment).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
