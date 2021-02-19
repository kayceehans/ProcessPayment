using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.ENUM
{
   public enum PaymentStateEnum : byte
    {
        Pending = 0,
        Processed,
        Failed
    }
}
