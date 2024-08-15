using CertificateVerificationAPI.DataAccess.Abstract;
using CertificateVerificationAPI.DTOS;
using CertificateVerificationAPI.Entities;
using CertificateVerificationAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CertificateVerificationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordService _passwordService;

        public LoginsController(IUserRepository userRepository, PasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        [HttpGet]
        public IActionResult Login(string email, string password)
        {
            User user =  _userRepository.GetByEmail(email);

            password = password.Replace("a", "");

            if (email != user.Email)
                return BadRequest("email eşleşmiyor");

            PasswordVerificationResult passwordVerificationResult =  _passwordService.VerifyHashedPassword(user: user, hashedPassword: user.Password, providedPassword: password);

            if(passwordVerificationResult.ToString() == "Failed")
                return BadRequest("şifre eşleşmiyor");

            return Ok(user);
        }
    }
}
