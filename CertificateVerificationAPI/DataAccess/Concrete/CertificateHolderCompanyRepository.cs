using CertificateVerificationAPI.Context;
using CertificateVerificationAPI.DataAccess.Abstract;
using CertificateVerificationAPI.Entities;

namespace CertificateVerificationAPI.DataAccess.Concrete
{
    public class CertificateHolderCompanyRepository : GenericRepository<CertificateHolderCompany>, ICertificateHolderCompanyRepository
    {
        public CertificateHolderCompanyRepository(CertificateDbContext context) : base(context)
        {
        }
    }
}
