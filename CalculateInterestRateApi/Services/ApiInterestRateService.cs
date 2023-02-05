using CalculateInterestRateApi.Entities;
using CalculateInterestRateApi.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CalculateInterestRateApi.Services
{
    public class ApiInterestRateService : IApiInterestRateService
    {
        private static string _interestRateApiUrl; 
        private readonly IRequestService _requestService;

        public ApiInterestRateService(IOptions<ApiSettings> configuration, IRequestService requestService)
        {
            _interestRateApiUrl = configuration.Value.ApiInterestRateUrl;
            _requestService = requestService;
        }

        public async Task<CurrentRateApiResponse> GetCurrentRate()
        {
            return JsonConvert.DeserializeObject<CurrentRateApiResponse>(await _requestService.Request(_interestRateApiUrl, HttpMethod.Get)); 
        }

    }
}
