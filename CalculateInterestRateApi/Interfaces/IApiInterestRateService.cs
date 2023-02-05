using CalculateInterestRateApi.Entities;

namespace CalculateInterestRateApi.Interfaces
{
    public interface IApiInterestRateService
    {
        Task<CurrentRateApiResponse> GetCurrentRate();
    }
}
