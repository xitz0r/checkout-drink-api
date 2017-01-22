using CheckoutAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutAPI.DAO
{
    public class DrinkDAO
    {
        private static Dictionary<string, Drink> database = new Dictionary<string, Drink>();

        public void AddOrUpdate(Drink drink)
        {
            if (database.ContainsKey(drink.Name))
                database.Remove(drink.Name);
            database.Add(drink.Name, drink);
        }

        public long GetQuantity()
        {
            return database.Count();
        }

        public void Remove(string name)
        {
            database.Remove(name);
        }

        public void RemoveAll()
        {
            database = new Dictionary<string, Drink>();
        }
    }
}