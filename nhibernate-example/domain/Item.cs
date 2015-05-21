using System;
using System.Text;

namespace domain
{
    public class Item
    {
        public virtual double Price { get; set; }
        public virtual string Name { get; set; }
        public virtual int ItemId { get; set; }

        public virtual string showDetails()
        {
            StringBuilder ret = new StringBuilder("");

            ret = ret.Append(Name).Append("\t");
            ret = ret.Append(Price).Append("\t");

            return ret.ToString();
        }
    }
}
