using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domain
{
    public class PayPalPayment : IPaymentType
    {
        public virtual int ID { get; protected set; }
        public virtual string AccountName { get; set; }

        #region IPaymentType Implementation

        public virtual string Description
        {
            get { return "PayPal"; }
        }

        public virtual string PaymentDetails()
        {
            return string.Format("PayPal Payment by {0} ", AccountName);
        }

        public static string DiscriminatorDefinition()
        {
            return "PayPalPayment";
        }


        #endregion
    }
}
