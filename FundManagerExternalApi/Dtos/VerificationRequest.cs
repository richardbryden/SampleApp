namespace FundManagerVerificationApi.Dtos
{
    public class VerificationRequest
    {
        public int FundId { get; set; }
        public int ManagerId { get; set; }
        public string VerificationRequestInfo { get; set; }
    }
}
