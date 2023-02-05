using CalculateInterestRateApi.Entities;

namespace CalculateInterestRateApi.Interfaces
{
    public interface ICalculateService
    {
        Task<decimal?> GetCalculate(decimal initialValue, int months);
    }
}
