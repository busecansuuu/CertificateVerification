namespace CertificateVerification.DTOS
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; } // DTO'da plain password tutulabilir
        public string? PhoneNumber { get; set; }
        public string? Department { get; set; }
        public string? Role { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}

