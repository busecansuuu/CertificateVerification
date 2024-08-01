using CertificateVerificationAPI.DataAccess.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CertificateVerificationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {
        private readonly ICertificateRepository _certificateRepository;

        public CertificatesController(ICertificateRepository certificateRepository)
        {
            _certificateRepository = certificateRepository;
        }

        [HttpGet("GetCertificates")]
        public IActionResult GetCertificates()
        {
            var certificates = _certificateRepository.GetList();
            return Ok(certificates);
        }
    }
}
