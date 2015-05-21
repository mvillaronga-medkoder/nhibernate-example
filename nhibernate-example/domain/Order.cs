using System.Collections.Generic;
using System.Text;

namespace domain
{
    /// <summary>
    /// Represents a bog standard inventory order
    /// </summary>
    public class Order
    {
        public Order() {
            Items = new List<OrderItem>();
        }

        public virtual int Id { get; protected set; }
        public virtual int ReferenceNumber { get; set; }
        public virtual IList<OrderItem> Items { get; set; }
        public virtual IPaymentType Payment { get; set; }

        public virtual string PaymentType { get; protected set; }

        public virtual string showDetails()
        {
            StringBuilder ret = new StringBuilder("");

            ret.Append("Reference Number:").Append(ReferenceNumber).AppendLine("");
            ret.Append("Payment Details:").Append(Payment.PaymentDetails()).AppendLine("");
            foreach (OrderItem oi in Items)
                ret.AppendLine(oi.details());

            return ret.ToString();
        }
    }
}
