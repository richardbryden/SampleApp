using FundAdministration.Lib;
using FundAdministration.Models;
using FundAdministration.Service;
using Microsoft.AspNetCore.Mvc;

namespace FundAdministration.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FundController : ControllerBase
    {
        private readonly IFundService _funds;
        private readonly ILogger<FundController> _logger;

        public FundController(IFundService funds, ILogger<FundController> logger)
        {
            _funds = funds;
            _logger = logger;
        }

        [HttpGet(Name = "GetAllFunds")]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Getting funds");
            var res =  await _funds.GetAllFunds();
            return Ok(res);
        }

        [HttpPost(Name = "CreateFund")]
        public async Task<IActionResult> Post([FromBody] Fund fund)
        {
            _logger.LogInformation("Creating fund");
            var res = await _funds.CreateFundAsync(fund);
            return Ok(res);
        }

        [HttpPut(Name = "UpdateFund")]
        public async Task<IActionResult> Put([FromBody] Fund fund)
        {
            _logger.LogInformation("Updating funds");
            var res = await _funds.UpdateFundAsync(fund);
            return Ok(res);
        }

        [HttpDelete("{id}", Name = "DeleteFund")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("Deleting funds {id}",id);
            await _funds.DeleteFundAsync(id);
            return Ok();
        }

        [HttpGet("{id}", Name = "GetFund")]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation("Getting fund {id}",id);
            var res = await _funds.GetFundAsync(id);
            return Ok(res);
        }

        [HttpGet]
        [Route("stats")]
        public async Task<IActionResult> GetStats(string fundID)
        {
            _logger.LogInformation("Getting fund stats");

            var funds = new FundFunctions();
            var res = await _funds.GetAllFunds();
           
            var total = funds.GetFundTotal(res);
            var count = funds.GetFundCount(res);
            var average = funds.GetFundAverage(res);
            var highest = funds.GetFundWithHighestFundValue(res);

            return Ok(new { total, count, average, highest });
        }

    }
}