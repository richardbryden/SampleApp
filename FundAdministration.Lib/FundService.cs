using FundAdministration.Db;
using FundAdministration.Models;
using Microsoft.EntityFrameworkCore;

namespace FundAdministration.Service
{
    public class FundService : IFundService
    {
        private readonly FundAdministrationContext _fundAdministrationContext;

        public FundService(FundAdministrationContext fundAdministrationContext)
        {
            _fundAdministrationContext = fundAdministrationContext;
        }

        public async Task<Fund> CreateFundAsync(Fund fund)
        {
            var res = await _fundAdministrationContext.Funds.AddAsync(fund);

            await _fundAdministrationContext.SaveChangesAsync();

            return res.Entity;
        }

        public async Task DeleteFundAsync(int id)
        {
            _fundAdministrationContext.Funds.Remove(new Fund { FundId = id });

            await _fundAdministrationContext.SaveChangesAsync();
        }

        public async Task<List<Fund>> GetAllFunds()
        {
            var res =  await _fundAdministrationContext.Funds.ToListAsync();
            return res;
        }

        public async Task<Fund?> GetFundAsync(int id)
        {
           return await _fundAdministrationContext.Funds.FindAsync(id);
        }

        public async Task<Fund> UpdateFundAsync(Fund fund)
        {
            var res = _fundAdministrationContext.Funds.Update(fund);

            await _fundAdministrationContext.SaveChangesAsync();

            return res.Entity;
        }
    }
}