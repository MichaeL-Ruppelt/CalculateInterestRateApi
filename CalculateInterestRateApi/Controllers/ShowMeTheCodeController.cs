using CalculateInterestRateApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CalculateInterestRateApi.Controllers
{
    [ApiController]
    [Route("showmethecode")]
    public class ShowMeTheCodeController : Controller
    {
        private readonly ILogger<CalculateInterestRateController> _logger;
        public ShowMeTheCodeController(ILogger<CalculateInterestRateController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetUrlCodeFromGithub()
        {
            return Ok("https://github.com/MichaeL-Ruppelt/CalculateInterestRateApi");
        }
    }
}
