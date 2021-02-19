using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.API.ViewModel
{
    public class PaymentViewModel
    {               
        public string CreditCardNumber { get; set; }        
        public string CardHolder { get; set; }       
        public DateTime ExpirationDate { get; set; }        
        public string SecuirtyCode { get; set; }        
        public decimal Amount { get; set; }
        public int PaymentState { get; set; }
    }
}
