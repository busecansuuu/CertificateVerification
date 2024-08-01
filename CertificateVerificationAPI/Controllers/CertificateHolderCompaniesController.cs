using CertificateVerificationAPI.DataAccess.Abstract;
using CertificateVerificationAPI.DataAccess.Concrete;
using CertificateVerificationAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CertificateVerificationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateHolderCompaniesController : ControllerBase
    {
        private readonly ICertificateHolderCompanyRepository _companyRepository;
        private object _companyRespository;

        public CertificateHolderCompaniesController(ICertificateHolderCompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        [HttpGet("Get CertificateHolderCompanies")]
        public IActionResult GetCertificateHolderCompaniesList()
        {
            var certificationholdercompanies = _companyRepository.GetList();
            return Ok(certificationholdercompanies);
        }

        [HttpGet("{id}")]
        public IActionResult GetCertificateHolderCompanies(int id)
        {
            var certificate = _companyRepository.GetByID(id);   
            return Ok(certificate);
        }
        [HttpPost]
        public IActionResult AddCertificateHolderCompanies(CertificateHolderCompany certificateHolderCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _companyRepository.Insert(certificateHolderCompany);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCertificateHolderCompanies(int id)
        {
            var CertificateHolderCompanies = _companyRepository.GetByID(id);
            _companyRepository.Delete(CertificateHolderCompanies);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateCertificateHolderCompanies(CertificateHolderCompany certificateHolderCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _companyRepository.Update(certificateHolderCompany);
            return Ok();
        }

    }
}
