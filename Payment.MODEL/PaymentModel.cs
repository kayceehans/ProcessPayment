using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Payment.MODEL
{
   public class PaymentModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(19, ErrorMessage = "Card Number can contain only 20 characters")]
        public string CreditCardNumber { get; set; }
        [Required(ErrorMessage = "Card Holder is compulsory")]
        public string CardHolder { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpirationDate { get; set; }
        [StringLength(3)]
        public string SecuirtyCode { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public int PaymentState { get; set; }
    }
}
