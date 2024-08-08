namespace CertificateVerification.DTOS
{
    public class CertificateDTO
    {
        public int Id { get; set; }
        public int CertificateHolderCompanyId { get; set; }
        public int UserId { get; set; }
        public string? CertificateOwnerName { get; set; }
        public string? CertificateName { get; set; }
        public DateTime GivenDate { get; set; }
        public DateTime FinishedDate { get; set; }
    }
}
