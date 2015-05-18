using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domain
{


    public class CreditCardPayment : IPaymentType
    {
        public int Id { get; protected set; }
        public string CardholderName { get; set; }
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public DateTime ExpiryDate { get; set; }

        #region IPaymentType Implementation
        public string Description
        {
            get { return "Credit Card"; }
        }

        public string PaymentDetails()
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
