using CheckoutAPI.DAO;
using CheckoutAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CheckoutAPI.Controllers
{
    public class DrinkController : ApiController
    {
        private static DrinkDAO drinkDAO = new DrinkDAO();

        // DELETE: api/Drink/5
        public IHttpActionResult Delete([FromUri]int id)
        {
            try
            {
                drinkDAO.Remove(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("Id doesn't exist");
            }
        }

        // DELETE: api/Drink?name=name
        public IHttpActionResult Get([FromUri]string name, [FromUri]int quantity)
        {
            try
            {
                Drink drink = drinkDAO.Get(name, quantity);
                return Ok(drink);
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("Drink with such name and quantity doesn't exist");
            }
        }

        // GET: api/Drink
        public IHttpActionResult Get()
        {
            return Ok(drinkDAO.GetAll());
        }

        // POST: api/Drink
        [ResponseType(typeof(Drink))]
        public IHttpActionResult Post([FromBody]Drink drink)
        {
            if (drink == null)
                return BadRequest("Invalid data");

            try
            {
                drinkDAO.Add(drink);
                return Ok(drink);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest("Id or name already exist");
            }
            catch (Exception)
            {
                return BadRequest("Invalid data");
            }
        }

        // PUT: api/Drink/5
        public IHttpActionResult Put([FromUri]int id, [FromBody]Drink drink)
        {
            drink.Id = id;
            try
            {
                Drink oldDrink = drinkDAO.Get(id);
                if (drink.Name != oldDrink.Name)
                    return BadRequest("Different name, only quantity is updatable");
                drinkDAO.Update(drink);
                return Ok(drink);
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("Id doesn't exist");
            }
        }
    }
}
