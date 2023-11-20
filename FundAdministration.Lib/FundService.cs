using FundAdministration.Db;
using FundAdministration.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ExceptionServices;

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
            Fund? fundToRemove = _fundAdministrationContext.Funds.FirstOrDefault(f => f.FundId == id);

           if(fundToRemove == null)
            {
                throw new Exception("Fund to delete not found");
            }
            _fundAdministrationContext.Funds.Remove(fundToRemove);

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