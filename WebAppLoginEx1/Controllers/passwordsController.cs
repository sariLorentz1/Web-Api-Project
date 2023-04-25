using entities;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppLoginEx1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class passwordsController : ControllerBase
    {

        IPasswordsService service;

        public passwordsController(IPasswordsService service)
        {
            this.service = service;
        }

        // GET: api/<passwordsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<passwordsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<passwordsController>
        [HttpPost]
        public int Post([FromBody] Password password)
        {
            return service.getPasswordRate(password);
        }

        // PUT api/<passwordsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<passwordsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
