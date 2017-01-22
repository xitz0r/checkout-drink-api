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
            drinkDAO.AddOrUpdate(new Drink("pepsi", 2));
            Assert.AreEqual(1, drinkDAO.GetQuantity());
        }

        [Test]
        public void AddingOneDrinkAndRemovingIt()
        {
            drinkDAO.AddOrUpdate(new Drink("pepsi", 2));
            drinkDAO.Remove("pepsi");
            Assert.AreEqual(0, drinkDAO.GetQuantity());
        }

        [Test]
        public void InitializingWithZeroDrink()
        {
            Assert.AreEqual(0, drinkDAO.GetQuantity());
        }

        [Test]
        public void RemovingAllDrinks()
        {
            drinkDAO.AddOrUpdate(new Drink("pepsi", 2));
            drinkDAO.AddOrUpdate(new Drink("coke", 1));
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
