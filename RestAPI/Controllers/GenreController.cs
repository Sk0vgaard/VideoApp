using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoAppBLL;
using VideoAppBLL.BO;

namespace RestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/genres")]
    public class GenreController : Controller
    {
        BLLFacade facade = new BLLFacade();

        //POST: api/Videoes
        [HttpPost]
        public IActionResult Post([FromBody] GenreBO genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.GenreService.Create(genre));
        }
    }
}