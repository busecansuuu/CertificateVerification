using CertificateVerification.DTOS;
using CertificateVerification.Services;
using CertificateVerificationAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CertificateVerification.Controllers
{
    public class LoginController : Controller
    {

        private readonly HttpClientServiceAction _httpClientService;

        public LoginController(HttpClientServiceAction httpClientService)
        {
            _httpClientService = httpClientService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDTO loginDTO)
        {
            User user = await _httpClientService.InvokeAsync<User>($"Logins/?email={loginDTO.Email}&password={loginDTO.Password+"a"}");

            if (user.Role == "admin")
                return RedirectToAction("Index", "AdminCertificate");
            return RedirectToAction("CertificateVerificationFiltering", "Home");
        }
        public IActionResult LogOut()
        {
            return RedirectToAction("Index", "Login");
        }
    }
}
