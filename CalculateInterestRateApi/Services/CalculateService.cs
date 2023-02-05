using CalculateInterestRateApi.Entities;
using CalculateInterestRateApi.Interfaces;

namespace CalculateInterestRateApi.Services
{
    public class CalculateService : ICalculateService
    {
        private static double baseRate = 1;
        private readonly IApiInterestRateService _apiCurrentRate;

        public CalculateService(IApiInterestRateService apiCurrentRate)
        {
            _apiCurrentRate = apiCurrentRate;
        }
        public async Task<decimal?> GetCalculate(decimal initialValue, int months)
        {
            var currentRate = await _apiCurrentRate.GetCurrentRate(); 

            if(currentRate is null)
                return null;

            return CalculateInterestRate(initialValue, months, (double)currentRate.CurrentRate);
        }

        private decimal CalculateInterestRate(decimal initialValue, int months, double rate)
        {
            var initialValueDouble = Convert.ToDouble(initialValue);
            var value = initialValueDouble * (Math.Pow(baseRate + rate, months));
            return Math.Round((decimal)value, 2);
        }

    }
}
