using AutoMapper;
using CertificateVerificationAPI.DTOS;
using CertificateVerificationAPI.Entities;

namespace CertificateVerificationAPI.Mapping
{
    public class APIMapping : Profile
    {
        public APIMapping()
        {
            //Certificate -- CertificateDTO mapping
            CreateMap<Certificate, CertificateDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<CertificateHolderCompany, CertificateHolderCompanyDTO>().ReverseMap();
        }
    }
}
