using entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using AutoMapper;
using DTO;
using Stripe;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppLoginEx1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class categoriesController : ControllerBase
    {
        ICategoryService _service;
        IMapper _mapper;

        public categoriesController(ICategoryService service, IMapper mapper)
        {
          _service = service;
            _mapper = mapper;
        }
       
        // GET: api/<categoriesController>
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            IEnumerable<Category> categories = await _service.getCategories();
            if (categories != null)
            {
                IEnumerable<CategoryDTO> categoriesDTO = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);
                return Ok(categoriesDTO);
            }
            return BadRequest("No categories");
        }

        ////GET api/<categoriesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<categoriesController>
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Post([FromBody] CategoryDTO categoryDTO)
        {
            Category category = _mapper.Map<CategoryDTO,Category >(categoryDTO);

            Category created =await _service.addNewCategory(category);
            if (created != null)
            {
                CategoryDTO categoryCreated= _mapper.Map<Category, CategoryDTO> (created);
                return CreatedAtAction(nameof(Get), new { id = categoryCreated.Id }, categoryCreated);
            }

            return BadRequest("Don't success");
        }



    }
}
