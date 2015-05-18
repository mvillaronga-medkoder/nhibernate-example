using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domain
{
    public class PayPalPayment : IPaymentType
    {
        public int ID { get; protected set; }
        public string AccountName { get; set; }

        #region IPaymentType Implementation

        public string Description
        {
            get { return "PayPal"; }
        }

        public string PaymentDetails()
        {
            return string.Format("PayPal Payment by {0} ", AccountName);
        }

        public static string DiscriminatorDefinition()
        {
            return "PAY_PAL_PAYMENT";
        }


        #endregion
    }
}
