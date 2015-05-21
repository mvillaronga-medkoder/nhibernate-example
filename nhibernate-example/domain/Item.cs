using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domain
{
    public class Item
    {
        public virtual double Price { get; set; }
        public virtual string Name { get; set; }
        public virtual int ItemId { get; set; }
    }
}
