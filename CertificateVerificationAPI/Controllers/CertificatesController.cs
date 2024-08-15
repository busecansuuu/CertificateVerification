using AutoMapper;
using CertificateVerificationAPI.DataAccess.Abstract;
using CertificateVerificationAPI.DTOS;
using CertificateVerificationAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CertificateVerificationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {
        private readonly ICertificateRepository _certificateRepository;
        private readonly IMapper _mapper;

        public CertificatesController(ICertificateRepository certificateRepository, IMapper mapper)
        {
            _certificateRepository = certificateRepository;
            _mapper = mapper;
        }

        [HttpGet("GetCertificates")]
        public IActionResult GetCertificatesList()
        {
            var certificates = _certificateRepository.GetList();
            return Ok(certificates);
        }
        [HttpGet("{id}")]
        public IActionResult GetCertificates(int id)
        {
            var certificate = _certificateRepository.GetByID(id);
            return Ok(certificate);
        }
        [HttpPost]
        public IActionResult AddCertificates([FromBody] CertificateDTO certificateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // Map the DTO to the entity
            var certificateEntity = _mapper.Map<Certificate>(certificateDto);

            // Insert the entity
            _certificateRepository.Insert(certificateEntity);

            // Optionally, map the entity back to a DTO for the response
            var createdCertificateDto = _mapper.Map<CertificateDTO>(certificateEntity);

            return Ok(createdCertificateDto);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCertificates(int id)
        {
            var Certificates = _certificateRepository.GetByID(id);
            _certificateRepository.Delete(Certificates);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCertificates(CertificateDTO certificateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Certificate certificateEntity = _mapper.Map<Certificate>(certificateDTO);
            _certificateRepository.Update(certificateEntity);

            return Ok();
        }
    }
}
