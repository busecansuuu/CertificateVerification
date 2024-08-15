using CertificateVerification.DTOS;
using CertificateVerification.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CertificateVerification.Controllers
{
    public class AdminUserController : Controller
    {
        private readonly HttpClientServiceAction _httpClientService;

        public AdminUserController(HttpClientServiceAction httpClientService)
        {
            _httpClientService = httpClientService;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _httpClientService.InvokeAsync<List<UserDTO>>("Users/GetUsers");
            return View(values);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDTO userDTO)
        {
            userDTO.Password = string.Empty;
            userDTO.RegisterDate = DateTime.Now;
            bool isSucceded = await _httpClientService.CreateAsync<UserDTO>("Users", userDTO);
            return isSucceded ? RedirectToAction("Index") : View();
        }

        public async Task<IActionResult> RemoveUser(int id)
        {
            bool succeded = await _httpClientService.RemoveAsync($"Users/{id}");
            return succeded ? RedirectToAction("Index") : View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(int id)
        {
            var values = await _httpClientService.InvokeAsync<UserDTO>($"Users/{id}");

            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserDTO userDTO)
        {
            UserDTO user = await _httpClientService.InvokeAsync<UserDTO>($"Users/{userDTO.Id}");

            userDTO.Password = user.Password;
            userDTO.RegisterDate = user.RegisterDate;

            bool succeded = await _httpClientService.UpdateAsync<UserDTO>($"Users/{userDTO.Id}", userDTO);
            return succeded ? RedirectToAction("Index") : View();
        }

    }
}
