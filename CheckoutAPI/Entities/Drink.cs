using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutAPI.Entities
{
    public class Drink
    {
        public string Name { get; private set; }
        public long Quantity { get; private set; }

        public Drink(string name, long quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }
    }
}