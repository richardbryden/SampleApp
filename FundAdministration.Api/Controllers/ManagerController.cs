using FundAdministration.Dtos;
using FundAdministration.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Runtime.InteropServices;

namespace FundAdministration.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;
        private readonly ILogger<ManagerController> _logger;

        public ManagerController(IManagerService managers, ILogger<ManagerController> logger)
        {
            _managerService = managers;
            _logger = logger;
        }

        [HttpGet(Name = "GetManagers")]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Getting funds");
            var res =  await _managerService.GetManagers();
            return Ok(res);
        }

        [HttpPost(Name = "AssignFund")]
        public async Task<IActionResult> Post([FromBody] AssignFundRequest request)
        {
            _logger.LogInformation("Assigning fund");
            var res = await _managerService.AssignFund(request.ManagerId, request.FundId);
            return Ok(res);
        }

        [HttpGet("{managerId}/{fundId}", Name = "VerifyManagerFund")]
        public async Task<IActionResult> Post(int managerId, int fundId)
        {
            _logger.LogInformation("Verifying fund and manager");

            var res = await _managerService.VerifyManagerFund(managerId, fundId);
            return Ok(res);
        }
    }
}