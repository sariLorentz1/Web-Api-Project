using AutoMapper;
using DTO;
using entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service;
using Stripe;
using System.Reflection.PortableExecutable;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppLoginEx1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {

        IUserService _service;
        IPasswordsService _servicePass;
        IMapper _mapper;
        ILogger<usersController> _logger;
        public usersController(IUserService service, IPasswordsService servicePass, IMapper mapper,ILogger<usersController> logger)
        {
            _service = service;
            _servicePass = servicePass;
            _mapper = mapper;
            _logger = logger;
        }



        // GET api/<usersController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await _service.getbyIdAsync(id);
        }


        // POST api/<usersController>


        [HttpPost]
        public async Task<ActionResult<UserDTO>> LoginPost([FromBody] UserDTO loginUserDTO)
        {
            User loginUser = _mapper.Map<UserDTO, User>(loginUserDTO);
            User found = await _service.loginAsync(loginUser);
            if (found != null)
            {
                _logger.LogInformation($"user {loginUserDTO.FirstName},{loginUserDTO.LastName},{loginUserDTO.Email} succeed to login");

                UserDTO foundDTO = _mapper.Map<User, UserDTO>(found);
                //_logger.LogInformation($"Login - userName: {foundDTO.Email} at {DateTime.UtcNow.ToLongTimeString()}");
                return foundDTO;
            }
            return NoContent();
        }



        [HttpPost("regist")]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO userRegistDTO)
        {
            Password pass = new Password(userRegistDTO.Password);
            if (_servicePass.getPasswordRate(pass) > 2)
            {
                User userRegist = _mapper.Map<UserDTO, User>(userRegistDTO);
                User userCreated = await _service.registerAsync(userRegist);
                if (userCreated != null)
                {
                    _logger.LogInformation($"user {userRegistDTO.FirstName},{userRegistDTO.LastName},{userRegistDTO.Email} created");

                    UserDTO userDTOCreated = _mapper.Map<User, UserDTO>(userCreated);
                    //_logger.LogInformation($"Regist - userName: {userDTOCreated.Email} at {DateTime.UtcNow.ToLongTimeString()}");
                    return CreatedAtAction(nameof(Get), new { id = userDTOCreated.Id }, userDTOCreated);
                }

            }
            return BadRequest("BadRequest");
        }

        // PUT api/<usersController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User userToUpdate)
        {
            await _service.updateAsync(userToUpdate, id);
        }

    }
}
