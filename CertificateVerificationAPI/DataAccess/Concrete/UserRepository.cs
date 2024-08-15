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

        public User GetByEmail(string email)
        {
            User? user = _context.Users.Where(x => x.Email == email).FirstOrDefault();
            return user;

        }
    }
}
