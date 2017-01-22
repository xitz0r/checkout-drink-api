using CheckoutAPI.DAO;
using CheckoutAPI.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutAPI.Tests.DAO
{
    [TestFixture]
    class DrinkDAOTests
    {
        public DrinkDAO drinkDAO;

        [OneTimeSetUp]
        public void PreparingTests()
        {
            drinkDAO = new DrinkDAO();
        }

        [Test]
        public void AddingOneDrink()
        {
            drinkDAO.Add(new Drink(1, "pepsi", 2));
            Assert.AreEqual(1, drinkDAO.GetQuantity());
        }

        [Test]
        public void AddingOneDrinkAndRemovingIt()
        {
            drinkDAO.Add(new Drink(1, "pepsi", 2));
            drinkDAO.Remove(1);
            Assert.AreEqual(0, drinkDAO.GetQuantity());
        }

        [Test]
        public void AddingTwoDrinksWithTheSameId()
        {
            drinkDAO.Add(new Drink(1, "pepsi", 2));
            Assert.Throws<InvalidOperationException>(()=>drinkDAO.Add(new Drink(1, "coke", 4)));
        }

        [Test]
        public void AddingTwoDrinksWithTheSameName()
        {
            drinkDAO.Add(new Drink(1, "pepsi", 2));
            Assert.Throws<InvalidOperationException>(() => drinkDAO.Add(new Drink(2, "pepsi", 4)));
        }

        [Test]
        public void InitializingWithZeroDrink()
        {
            Assert.AreEqual(0, drinkDAO.GetQuantity());
        }

        [Test]
        public void RemovingAllDrinks()
        {
            drinkDAO.Add(new Drink(1, "pepsi", 2));
            drinkDAO.Add(new Drink(2, "coke", 1));
            drinkDAO.RemoveAll();
            Assert.AreEqual(0, drinkDAO.GetQuantity());
        }

        [TearDown]
        public void TearDown()
        {
            this.drinkDAO.RemoveAll();
        }
    }
}
