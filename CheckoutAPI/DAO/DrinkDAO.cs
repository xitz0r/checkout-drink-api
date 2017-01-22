﻿using CheckoutAPI.Entities;
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
            if (database.ContainsKey(drink.Id) || DrinkExists(drink))
                throw new InvalidOperationException();

            database.Add(nextId++, drink);
        }

        private bool DrinkExists(Drink drink)
        {
            return database.ContainsValue(drink);
        }

        public long GetQuantity()
        {
            return database.Count();
        }

        public void Remove(int id)
        {
            database.Remove(id);
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