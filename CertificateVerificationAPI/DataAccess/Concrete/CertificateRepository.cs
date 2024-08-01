using CertificateVerificationAPI.Context;
using CertificateVerificationAPI.DataAccess.Abstract;
using CertificateVerificationAPI.Entities;

namespace CertificateVerificationAPI.DataAccess.Concrete
{
    public class CertificateRepository : GenericRepository<Certificate>,ICertificateRepository
    {
        public CertificateRepository(CertificateDbContext context) : base(context)
        {
        }
    }
}
