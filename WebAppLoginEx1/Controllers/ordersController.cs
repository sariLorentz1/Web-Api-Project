using AutoMapper;
using DTO;
using entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using Stripe;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppLoginEx1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ordersController : ControllerBase
    {
        IOrderService _service;
        IMapper _mapper;

        public ordersController(IOrderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<OrderDTO> Get(int id)
        {
            Order order = await _service.getOrderAsync(id);
            OrderDTO orderDTO = _mapper.Map<Order, OrderDTO>(order);
            return orderDTO;
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post([FromBody] OrderDTO orderDTO)
        {
            Order order = _mapper.Map<OrderDTO, Order>(orderDTO);
            Order orderCreated = await _service.addNewOrder(order);
            if (orderCreated != null)
            {
                OrderDTO orderCreatedDTO = _mapper.Map<Order, OrderDTO>(orderCreated);
                return CreatedAtAction(nameof(Get), new { id = orderCreatedDTO.Id }, orderCreatedDTO);
            }
            return BadRequest();
        }

    }
}
