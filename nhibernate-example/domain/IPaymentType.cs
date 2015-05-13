using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domain
{
    public interface IPaymentType
    {
        /// <summary>
        /// Name of the payment type
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Generates a payment details string
        /// </summary>
        /// <returns></returns>
        string PaymentDetails();
    }
}
