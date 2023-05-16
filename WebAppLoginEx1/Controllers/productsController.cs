using AutoMapper;
using DTO;
using entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using Stripe;
using Product = entities.Product;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppLoginEx1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

 
    public class productsController : ControllerBase
    {
        IProductService _service;
        IMapper _mapper;

        public productsController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        // GET: api/<productsController>
        [HttpGet]
  
        public async Task<IEnumerable<ProductDTO>> Get([FromQuery] IEnumerable<string>? categoryId, string? name, int? minPrice, int? maxPrice)
        {
            IEnumerable<Product> products = await _service.getProducts(categoryId, name, minPrice, maxPrice);
            IEnumerable<ProductDTO> productsDTO = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return productsDTO;

        }


        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Post([FromBody] ProductDTO productDTO)
        {
            Product product = _mapper.Map<ProductDTO, Product>(productDTO);
            Product found = await _service.addNewProduct(product);
            if (found != null)
            {
                ProductDTO addProductDTO = _mapper.Map<Product, ProductDTO>(found);
                return CreatedAtAction(nameof(Get), new { id = addProductDTO.Id }, addProductDTO);
            }
            return BadRequest();
        }
    }
}
