using FundManagerVerificationApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FundManagerVerificationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VerificationController : ControllerBase
    {
        private readonly ILogger<VerificationController> _logger;

        public VerificationController(ILogger<VerificationController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "VerifyManagedFund")]
        public async Task<IActionResult> Post([FromBody] VerificationRequest verificationRequest)
        {
            _logger.LogInformation("Verifying fund and manager");

            await Task.Delay(2000);

            var res = new VerificationResponse()
            {
                FundId = verificationRequest.FundId,
                ManagerId = verificationRequest.ManagerId,
                IsVerified = true,
                VerificationResponseInfo = "Fund and manager verified"
            };
            return Ok(res);
        }
    }
}