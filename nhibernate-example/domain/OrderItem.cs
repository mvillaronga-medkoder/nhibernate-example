using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domain
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }

        public double TotalPrice
        {
            get
            {
                if (null == Item)
                    throw new Exception("Item not set.");

                return Item.Price * Quantity;
            }
        }
    }
}
