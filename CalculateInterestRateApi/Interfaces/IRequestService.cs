namespace CalculateInterestRateApi.Interfaces
{
    public interface IRequestService
    {
        Task<string> Request(string uri, HttpMethod method);
    }
}
