using FundAdministration.Models;

namespace FundAdministration.Db
{
    public class DataSeeder
    {
        private const int _fundCount = 10;
        private const int _managerCount = 10;
        private readonly FundAdministrationContext _fundAdministrationContext;
        private readonly Random _rand = new();

        public DataSeeder(FundAdministrationContext fundAdministrationContext)
        {
            _fundAdministrationContext = fundAdministrationContext;
        }

        public async Task SeedData()
        {
            SeedFunds();
            await _fundAdministrationContext.SaveChangesAsync();

            SeedManagers();
            await _fundAdministrationContext.SaveChangesAsync();

        }

        private void SeedFunds()
        {
            for (int i = 1; i < _fundCount; i++)
            {
                Fund newFund = new()
                {
                    Name = $"Fund {i}",
                    OpenClosed = "Open",
                    InfoToBeVerified = $"Test Supplementary Info for Fund {i}",
                    IsVerified = false,
                    FundValue = _rand.Next(100, 100000)
                };

                _fundAdministrationContext.Funds.Add(newFund);
            }
         }

        private void SeedManagers()
        {
            for (int i = 1; i < _managerCount; i++)
            {
                Manager newManager = new()
                {
                    Name = $"Manager {i}",
                    SupplementaryInfo = $"Test Supplementary Info for Manager {i}",
                    ManagedFunds = new List<Fund>() 
                };

                var fundCount = _rand.Next(1, 4);

                for (int f = 0; f < fundCount; f++)
                {
                    var fundId = _rand.Next(1, _fundCount);
                    newManager.ManagedFunds.Add(_fundAdministrationContext.Funds.Where(x => x.FundId == fundId).First());
                }

                _fundAdministrationContext.Managers.Add(newManager);
            }
        }
    }
}