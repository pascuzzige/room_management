using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/room")]
    public class StanzeController : ControllerBase
    {
        private readonly StanzeContext db;

        public StanzeController(StanzeContext stanzeContext) 
        { 
            db = stanzeContext;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var stanze = db.Stanze.ToList();
            return Ok(stanze);
        }

        [HttpPost("new")]
        public IActionResult CreateNewRoom(string name)
        {
            var room = new Stanza()
            {
                Nome = name,
            };

            db.Stanze.Add(room);
            db.SaveChanges();

            return Ok(room);
        }
    }
}