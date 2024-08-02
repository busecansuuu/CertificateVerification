namespace CertificateVerification.DTOS
{
    public class CertificateHolderCompanyDTO
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}
