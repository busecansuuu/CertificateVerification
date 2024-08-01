using CertificateVerificationAPI.DataAccess.Abstract;
using CertificateVerificationAPI.DataAccess.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CertificateVerificationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetList();
            return Ok(users);
        }
    }
}
