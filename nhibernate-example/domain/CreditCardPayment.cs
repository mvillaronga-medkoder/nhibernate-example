using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domain
{


    public class CreditCardPayment : IPaymentType
    {
        public virtual int Id { get; protected set; }
        public virtual string CardholderName { get; set; }
        public virtual string CardNumber { get; set; }
        public virtual string CardType { get; set; }
        public virtual DateTime ExpiryDate { get; set; }

        #region IPaymentType Implementation
        public virtual string Description
        {
            get { return "Credit Card"; }
        }

        public virtual string PaymentDetails()
        {
            return string.Format("{0} CC payment for {1} with number {2} exp {4}", CardType, CardholderName, CardNumber, ExpiryDate);
        }

        public static string DiscriminatorDefinition()
        {
            return "CREDIT_CARD_PAYMENT";
        }


        #endregion
    }
}
