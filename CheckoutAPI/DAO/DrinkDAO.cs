using CheckoutAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutAPI.DAO
{
    public class DrinkDAO
    {
        private static Dictionary<int, Drink> database = new Dictionary<int, Drink>();
        static int nextId = 0;

        public void Add(Drink drink)
        {
            if (DrinkExists(drink))
                throw new InvalidOperationException();

            drink.Id = nextId++;
            database.Add(drink.Id, drink);
        }

        private bool DrinkExists(Drink drink)
        {
            return database.ContainsValue(drink);
        }

        public Drink Get(int id)
        {
            if (database.ContainsKey(id))
                return database[id];
            throw new KeyNotFoundException();
        }

        public Drink Get(string name, int quantity)
        {
            foreach(Drink drink in database.Values)
                if (drink.Name == name)
                {
                    if (drink.Quantity == quantity)
                        return drink;
                    break;
                }
                    
            throw new KeyNotFoundException();
        }

        public IEnumerable<Drink> GetAll()
        {
            return database.Values;
        }

        public long GetQuantity()
        {
            return database.Count();
        }

        public void Remove(int id)
        {
            if (database.ContainsKey(id))
                database.Remove(id);
            else
                throw new KeyNotFoundException();
        }

        public void RemoveAll()
        {
            database = new Dictionary<int, Drink>();
        }

        public void Update(Drink drink)
        {
            if (!database.ContainsKey(drink.Id))
                throw new InvalidOperationException();

            Remove(drink.Id);
            Add(drink);
        }
    }
}