namespace CertificateVerificationAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Department { get; set; }
        public string? Role { get; set; }
        public DateTime RegisterDate { get; set; }
        public List<Certificate>? Certificates { get; set; }

    }
}
