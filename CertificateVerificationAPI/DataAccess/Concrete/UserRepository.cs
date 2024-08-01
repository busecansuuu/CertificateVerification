using CertificateVerificationAPI.Context;
using CertificateVerificationAPI.DataAccess.Abstract;
using CertificateVerificationAPI.Entities;

namespace CertificateVerificationAPI.DataAccess.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(CertificateDbContext context) : base(context)
        {
        }
    }
}
