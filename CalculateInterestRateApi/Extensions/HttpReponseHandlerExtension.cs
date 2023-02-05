using System.Net;

namespace CalculateInterestRateApi.Extensions
{
    internal static class HttpReponseHandlerExtension
    {
        public static async Task EnsureSuccessStatusCodeAsync(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            string content = string.Empty;

            content += "RequestUri: " + response.RequestMessage?.RequestUri?.ToString();

            if (response.RequestMessage?.Headers?.Any() != false)
            {
                content += " Headers: ";
                foreach (var header in response.RequestMessage.Headers)
                {
                    content += header.Key + ": " + header.Value?.ToString();
                }
            }

            if (response.Content != null)
            {
                content += " ResponseContent: " + await response.Content.ReadAsStringAsync();
                response.Content.Dispose();
            }

            throw new SimpleHttpResponseException(response.StatusCode, content);
        }
    }

    public class SimpleHttpResponseException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public SimpleHttpResponseException(HttpStatusCode statusCode, string content) : base(content) => StatusCode = statusCode;
    }
}