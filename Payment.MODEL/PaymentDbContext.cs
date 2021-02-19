using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.MODEL
{
   public class PaymentDbContext : DbContext
    {
        public PaymentDbContext()
        {

        }
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
        {

        }

       public DbSet<PaymentModel> CardPayment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                 optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=PaymentDB;Integrated Security=True");
            }
        }
    }
}
