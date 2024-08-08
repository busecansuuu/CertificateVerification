using CertificateVerificationAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;

namespace CertificateVerificationAPI.Context
{
    public class CertificateDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-J4IEETI;initial Catalog=CertificateDb;integrated Security=true;TrustServerCertificate=true;");
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<CertificateHolderCompany> CertificateHolderCompanies { get; set; }
    }
}
