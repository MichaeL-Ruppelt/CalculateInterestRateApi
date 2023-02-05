using CalculateInterestRateApi.Extensions;
using CalculateInterestRateApi.Interfaces;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace CalculateInterestRateApi.Services
{
    public class RequestService : IRequestService
    {
        private readonly HttpClient _httpClient;

        public RequestService(HttpClient httpClient) => _httpClient = httpClient;

        //Simples request to get data, without headers and body.
        public async Task<string> Request(string uri, HttpMethod method)
        {
            HttpRequestMessage requestMessage = new(method, uri);
            var response = await _httpClient.SendAsync(requestMessage);

            await response.EnsureSuccessStatusCodeAsync();

            return await response.Content.ReadAsStringAsync();
        }

    }
}

