using entities;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppLoginEx1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

 
    public class productsController : ControllerBase
    {
        IProductService service;

        public productsController(IProductService service)
        {
            this.service = service;
        }
        // GET: api/<productsController>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get(int[] categryIds,int minPrice,int maxPrice,string productName,string description )
        {
            throw new NotImplementedException();
        }

        //public async Task<User> Get(int id)
        //{
        //    return await service.getbyIdAsync(id);
        //}

        //// GET api/<productsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<productsController>
        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            Product found = await service.addNewProduct(product);
            if (found != null)
                return found;
            return NoContent();
        }


        //// PUT api/<productsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<productsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
