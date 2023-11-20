using FundAdministration.Db;
using FundAdministration.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace FundAdministration.Service
{
    public class ManagerService : IManagerService
    {

        private readonly FundAdministrationContext _fundAdministrationContext;
        private readonly HttpClient _client = new HttpClient();

        public ManagerService(FundAdministrationContext fundAdministrationContext)
        {
            _fundAdministrationContext = fundAdministrationContext;
        }

        public async Task<Manager?> AssignFund(int managerId, int fundId)
        {
            var manager = _fundAdministrationContext.Managers.Include("ManagedFunds").FirstOrDefault(m => m.ManagerId == managerId);

            if (manager == null)
            {
                throw new Exception("Manager not found");
            }

            var fund = await _fundAdministrationContext.Funds.FindAsync(fundId);

            if (fund == null)
            {
                throw new Exception("Fund not found");
            }

            manager.ManagedFunds?.Add(fund);

            await _fundAdministrationContext.SaveChangesAsync();

            return manager;
        }

        public async Task<List<Manager>> GetManagers()
        {
            try
            {
                var res = await _fundAdministrationContext.Managers.Include("ManagedFunds").ToListAsync();
                return res;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> VerifyManagerFund(int managerId, int fundId)
        {
            string url = "https://localhost:7197/Verification";

            var payload = new
            {
                FundId = fundId,
                ManagerId = managerId,
                VerificationRequestInfo = "Verify fund and manager"
            };

            var jsonData = JsonConvert.SerializeObject(payload);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(url, content);

            string result = await response.Content.ReadAsStringAsync();

            dynamic? returnedData = JsonConvert.DeserializeObject<dynamic>(result);

            var johnValue = returnedData?.isVerified;

            return johnValue;
        }
    }
}
