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
        public async Task<IActionResult> IndexAsync()
        {
            //https://localhost:44320/api/CertificateHolderCompanies/GetCertificateHolderCompanies
            var values = await _httpClientService.InvokeAsync<List<CertificateHolderCompanyDTO>>("CertificateHolderCompanies/GetCertificateHolderCompanies");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
