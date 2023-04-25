using entities;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppLoginEx1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class categoriesController : ControllerBase
    {
        ICategoryService service;

        public categoriesController(ICategoryService service)
        {
            this.service = service;
        }
       
        // GET: api/<categoriesController>
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await service.getCategories();
        }

        //// GET api/<categoriesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<categoriesController>
        [HttpPost]
        public async Task<ActionResult<Category>> Post([FromBody] Category category)
        {
            Category found = await service.addNewCategory(category);
            if (found != null)
                return found;
            return NoContent();
        }


        //// PUT api/<categoriesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<categoriesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
