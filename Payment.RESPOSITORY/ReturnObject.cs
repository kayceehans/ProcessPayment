using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.RESPOSITORY
{
   public class ReturnObject
    {
        public long Id { get; set; }
        public bool Status { get; set; }
        public string StatusMessage { get; set; }
        public dynamic Data { get; set; }

    }
}
