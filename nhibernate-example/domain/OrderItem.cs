using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domain
{
    public class OrderItem
    {
        public virtual int Id { get; set; }
        public virtual Order Order { get; set; }
        public virtual Item Item { get; set; }
        public virtual int Quantity { get; set; }

        public virtual double TotalPrice
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
