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
    
        public int Id { get; protected set; }
        public int ReferenceNumber { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
        public IPaymentType Payment { get; set; }

    }
}
