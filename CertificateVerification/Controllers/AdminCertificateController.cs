using CertificateVerification.DTOS;
using CertificateVerification.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CertificateVerification.Controllers
{
    public class AdminCertificateController : Controller
    {
        private readonly HttpClientServiceAction _httpClientService;

        public AdminCertificateController(HttpClientServiceAction httpClientService)
        {
            _httpClientService = httpClientService;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _httpClientService.InvokeAsync<List<CertificateDTO>>("Certificates/GetCertificates");
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AddCertificate()
        {
            var values = await _httpClientService.InvokeAsync<List<CertificateHolderCompanyDTO>>("CertificateHolderCompanies/GetCertificateHolderCompanies");
            List<SelectListItem> HolderCompanies = (from x in values
                                                    select new SelectListItem
                                                    {
                                                        Text = x.CompanyName,
                                                        Value = x.Id.ToString()
                                                    }).ToList();
            ViewBag.HolderCompanies = HolderCompanies;

            var values2 = await _httpClientService.InvokeAsync<List<UserDTO>>("Users/GetUsers");
            List<SelectListItem> Users = (from x in values2
                                          select new SelectListItem
                                          {
                                              Text = x.Name,
                                              Value = x.Id.ToString()
                                          }).ToList();
            ViewBag.Users = Users;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCertificate(CertificateDTO certificateDTO)
        {
            certificateDTO.GivenDate = DateTime.UtcNow;
            bool isSucceded = await _httpClientService.CreateAsync<CertificateDTO>("Certificates", certificateDTO);
            return isSucceded ? RedirectToAction("Index") : View();
        }

        public async Task<IActionResult> RemoveCertificate(int id)
        {
            bool succeded = await _httpClientService.RemoveAsync($"Certificates/{id}");
            return succeded ? RedirectToAction("Index") : View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCertificate(int id)
        {
            var values = await _httpClientService.InvokeAsync<List<CertificateHolderCompanyDTO>>("CertificateHolderCompanies/GetCertificateHolderCompanies");
            List<SelectListItem> HolderCompanies = (from x in values
                                                    select new SelectListItem
                                                    {
                                                        Text = x.CompanyName,
                                                        Value = x.Id.ToString()
                                                    }).ToList();
            ViewBag.HolderCompanies = HolderCompanies;

            var values2 = await _httpClientService.InvokeAsync<List<UserDTO>>("Users/GetUsers");
            List<SelectListItem> Users = (from x in values2
                                          select new SelectListItem
                                          {
                                              Text = x.Name,
                                              Value = x.Id.ToString()
                                          }).ToList();
            ViewBag.Users = Users;

            var values3 = await _httpClientService.InvokeAsync<CertificateDTO>($"Certificates/{id}");

            return View(values3);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCertificate(CertificateDTO certificateDTO)
         {
            bool succeded = await _httpClientService.UpdateAsync<CertificateDTO>($"Certificates/{certificateDTO.Id}", certificateDTO);
            return succeded ? RedirectToAction("Index") : View();
        }

    }
}
