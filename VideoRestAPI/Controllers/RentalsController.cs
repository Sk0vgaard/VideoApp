using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoAppBLL;
using VideoAppBLL.BO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoRestAPI.Controllers
{
    [Route("api/[controller]")]
    public class RentalsController : Controller
    {
        BLLFacade facade = new BLLFacade();


        // GET: api/values
        [HttpGet]
        public IEnumerable<RentalBO> Get()
        {
            return facade.RentalService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public RentalBO Get(int id)
        {
            return facade.RentalService.Get(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]RentalBO rental)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.RentalService.Create(rental));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]RentalBO rental)
        {
            if (id != rental.Id)
            {
                return BadRequest("Path Id foes not match rental ID in json object.");
            }
            try
            {
                return Ok(facade.RentalService.Update(rental));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromBody]RentalBO rental)
        {
            if (id != rental.Id)
            {
                return BadRequest("The path Id does not match with the rental Id in json object.");
            }
            //TEST IF WORKS!
            try
            {
                return Ok(facade.RentalService.Delete(id));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}
