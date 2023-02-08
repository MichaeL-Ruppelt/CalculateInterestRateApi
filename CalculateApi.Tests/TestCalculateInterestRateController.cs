using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Xunit;
using Refit;

using CalculateApi.Tests.HttpClients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Xunit.Assert;

namespace APITemperatura.Testes
    {
        public class TestCalculateInterestRateController
        {
            private readonly ICalculateInterestRateApi _apiCalculateInterestRate;

            public void TestCalculateInterestRateController()
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile($"appsettings.json")
                    .AddEnvironmentVariables();
                var configuration = builder.Build();

                _apiCalculateInterestRate = RestService.For<ICalculateInterestRateApi>(configuration["UrlWebAppTestes"]);
            }

            [Theory]
            [InlineData(100.00, 5, 105.10)]
            public async Task TestCalculate(decimal initialValue,int months, decimal result)
            {
                var response = await _apiCalculateInterestRate.PostAsync(initialValue, months);
                response.StatusCode.Equals(HttpStatusCode.OK);
                Assert.Equal(result, response.Content.ValueCalculated);

            }

            [Fact]
            public async Task TestCalculate2()
            {
                var response = await _apiCalculateInterestRate.PostAsync((decimal)100.00, 5);
                Assert.Equal((decimal)105.10, response.Content.ValueCalculated);

            }
        }
    }