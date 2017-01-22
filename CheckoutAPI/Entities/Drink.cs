using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutAPI.Entities
{
    public class Drink
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public long Quantity { get; private set; }

        public Drink(int id, string name, long quantity)
        {
            this.Id = id;
            this.Name = name;
            this.Quantity = quantity;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Drink dr = obj as Drink;
            if (object.ReferenceEquals(dr, null))
                return false;

            return (dr.Name == Name);
        }

        public bool Equals(Drink dr)
        {
            if (object.ReferenceEquals(dr, null))
                return false;

            return (dr.Name == Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

    }
}