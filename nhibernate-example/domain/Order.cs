using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public virtual IEnumerable<OrderItem> Items { get; set; }
        public virtual IPaymentType Payment { get; set; }

    }
}
