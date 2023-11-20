using FundAdministration.Models;

namespace FundAdministration.Service
{
    public interface IManagerService
    {
        Task<List<Manager>> GetManagers();

        Task<Manager?> AssignFund(int managerId, int fundId);

        Task<bool> VerifyManagerFund(int managerId, int fundId);
    }
}