using Payment.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.RESPOSITORY
{
   public class UnitOfWork : IDisposable
    {
        private PaymentDbContext context = new PaymentDbContext();
        private Repository<PaymentModel> paymentRepository;

        public Repository<PaymentModel> PaymentRepository 
        { 
            get 
            { 
                if (this.paymentRepository == null) 
                { 
                    this.paymentRepository = new Repository<PaymentModel>(context); 
                }
                return paymentRepository;
            } 
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
