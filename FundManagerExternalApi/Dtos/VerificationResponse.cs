namespace FundManagerVerificationApi.Dtos
{
    public class VerificationResponse
    {
        public int FundId { get; set; }
        public int ManagerId { get; set; }
        public bool IsVerified { get; set; }
        public string VerificationResponseInfo { get; set; }
        public DateTime VerificationDateTime { get; set; } = DateTime.UtcNow;
    }
}
