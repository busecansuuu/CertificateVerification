using AutoMapper;
using CertificateVerificationAPI.DataAccess.Abstract;
using CertificateVerificationAPI.DataAccess.Concrete;
using CertificateVerificationAPI.DTOS;
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
        private readonly IMapper _mapper;

        public CertificateHolderCompaniesController(ICertificateHolderCompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        [HttpGet("GetCertificateHolderCompanies")]
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
        public IActionResult AddCertificateHolderCompanies([FromBody] CertificateHolderCompanyDTO certificateHolderCompanyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // Map the DTO to the entity
            var certificateHolderCompanyEntity = _mapper.Map<CertificateHolderCompany>(certificateHolderCompanyDto);

            // Insert the entity
            _companyRepository.Insert(certificateHolderCompanyEntity);

            // Optionally, map the entity back to a DTO for the response
            var createdCertificateDto = _mapper.Map<CertificateHolderCompanyDTO>(certificateHolderCompanyEntity);

            return Ok(createdCertificateDto);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCertificateHolderCompanies(int id)
        {
            var CertificateHolderCompanies = _companyRepository.GetByID(id);
            _companyRepository.Delete(CertificateHolderCompanies);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateCertificateHolderCompanies(CertificateHolderCompanyDTO certificateHolderCompanyDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            CertificateHolderCompany certificateHolderCompanyEntity = _mapper.Map<CertificateHolderCompany>(certificateHolderCompanyDTO);
            _companyRepository.Update(certificateHolderCompanyEntity);
            
            return Ok();
        }

    }
}
