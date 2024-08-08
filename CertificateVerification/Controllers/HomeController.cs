using CertificateVerification.DTOS;
using CertificateVerification.Models;
using CertificateVerification.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CertificateVerification.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClientServiceAction _httpClientService;

       
        public HomeController(ILogger<HomeController> logger, HttpClientServiceAction httpClientService)
        {
            _logger = logger;
            _httpClientService = httpClientService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _httpClientService.InvokeAsync<List<CertificateHolderCompanyDTO>>("CertificateHolderCompanies/GetCertificateHolderCompanies");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CertificateVerification(CertificateDTO certificateDTO)
        {
            var company = await _httpClientService.InvokeAsync<CertificateHolderCompanyDTO>($"CertificateHolderCompanies/{certificateDTO.CertificateHolderCompanyId}");
            var User = await _httpClientService.InvokeAsync<UserDTO>($"Users/{certificateDTO.UserId}");
            ViewBag.companyname = company.CompanyName;
            ViewBag.username = User.Name;
            return View(certificateDTO);
        }

        [HttpGet]
        public IActionResult CertificateVerificationFiltering()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CertificateVerificationFiltering(int certificateCode)
        {

            var values = await _httpClientService.InvokeAsync<CertificateDTO>($"Certificates/{certificateCode}");
            return RedirectToAction("CertificateVerification", values);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
