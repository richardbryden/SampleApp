using FundAdministration.Models;

namespace FundAdministration.Service
{
    public interface IFundService
    {
        Task<Fund?> GetFundAsync(int id); 

        Task<Fund> CreateFundAsync(Fund fund);

        Task<Fund> UpdateFundAsync(Fund fund);

        Task DeleteFundAsync(int id);

        Task<List<Fund>> GetAllFunds();
    }
}