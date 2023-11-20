using FundAdministration.Models;

namespace FundAdministration.Lib
{
    public class FundFunctions
    {
        public int GetFundTotal(IEnumerable<Fund> funds)
        {
            return funds.Sum(f => (int)f.FundValue);    
        }

        public int GetFundCount(IEnumerable<Fund> funds)
        {
            return funds.Count();
        }

        public int GetFundAverage(IEnumerable<Fund> funds)
        {
            return (int)funds.Average(f => f.FundValue);
        }

        public Fund GetFundWithHighestFundValue(IEnumerable<Fund> funds)
        {
            return funds.OrderByDescending(f => f.FundValue).First();
        }

        public void UpdateFundManager(Fund fund, Manager manager)
        {
            manager.ManagedFunds?.Add(fund);
        }
    }
}