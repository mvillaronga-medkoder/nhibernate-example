using System;
using System.Text;

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

        public virtual string details()
        {
            StringBuilder ret = new StringBuilder("");

            ret = ret.Append(Quantity).Append("\t");
            ret = ret.Append(Item.Name).Append("\t");
            ret = ret.Append(Item.Price).Append("\t");
            ret = ret.Append(TotalPrice);

            return ret.ToString();
        }

    }
}
