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

        // POST: api/Drink
        [ResponseType(typeof(Drink))]
        public IHttpActionResult Post([FromBody]Drink drink)
        {
            if (drink == null)
                return BadRequest("Invalid data");

            try
            {
                drinkDAO.Add(drink);
                return CreatedAtRoute("DefaultApi", new { id = drink.Id }, drink);
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
    }
}
