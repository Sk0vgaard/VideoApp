using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoAppBLL;
using VideoAppBLL.BO;

namespace VideoRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {

        BLLFacade facade = new BLLFacade();

        // GET: api/Users
        [HttpGet]
        public IEnumerable<UserBO> Get()
        {
            return facade.UserService.GetAll();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public UserBO Get(int id)
        {
            return facade.UserService.Get(id);
        }
        
        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody]UserBO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.UserService.Create(user));
        }
        
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UserBO user)
        {
            if (id != user.Id)
            {
                return BadRequest("Path Id does not match User ID in json object.");
            }
            try
            {
                return Ok(facade.UserService.Update(user));

            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.UserService.Delete(id);
        }
    }
}
