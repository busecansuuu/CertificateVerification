using Microsoft.AspNetCore.Identity;
using CertificateVerificationAPI.Entities;

namespace CertificateVerificationAPI.Services
{
    public class PasswordService
    {
        private readonly IPasswordHasher<User> _passwordHasher;

        public PasswordService(IPasswordHasher<User> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public string HashPassword(User user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }

        public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
        {
            return _passwordHasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
        }
    }
}
