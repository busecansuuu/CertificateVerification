using AutoMapper;
using CertificateVerificationAPI.DataAccess.Abstract;
using CertificateVerificationAPI.DataAccess.Concrete;
using CertificateVerificationAPI.DTOS;
using CertificateVerificationAPI.Entities;
using CertificateVerificationAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CertificateVerificationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly PasswordService _passwordService;

        public UsersController(IUserRepository userRepository, IMapper mapper, PasswordService passwordService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordService = passwordService;
        }
        [HttpGet("GetUsers")]
        public IActionResult GetUsersList()
        {
            var users = _userRepository.GetList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetUsers(int id)
        {
            var user = _userRepository.GetByID(id);
            return Ok(user);
        }
        [HttpPost]
        public IActionResult AddUsers([FromBody] UserDTO userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // Map the DTO to the entity
            var userEntity = _mapper.Map<User>(userDto);

            // Hash the password
            userEntity.Password = _passwordService.HashPassword(userEntity, userDto.Password);

            // Insert the entity
            _userRepository.Insert(userEntity);

            // Optionally, map the entity back to a DTO for the response
            var createdUserDto = _mapper.Map<UserDTO>(userEntity);

            return Ok(createdUserDto);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUsers(int id)
        {
            var Users = _userRepository.GetByID(id);
            _userRepository.Delete(Users);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateUsers(UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            User userEntity = _mapper.Map<User>(userDTO);

            // Hash the password if it's not null or empty
            if (!string.IsNullOrEmpty(userDTO.Password))
            {
                userEntity.Password = _passwordService.HashPassword(userEntity, userDTO.Password);
            }

            _userRepository.Update(userEntity);

            return Ok();
        }
    }
}
