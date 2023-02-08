using CalculateInterestRateApi.Entities;
using CalculateInterestRateApi.Interfaces;
using CalculateInterestRateApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CalculateInterestRateApi.Controllers
{
    [ApiController]
    [Route("CalculaJuros")]
    public class CalculateInterestRateController : ControllerBase
    {
        private readonly ILogger<CalculateInterestRateController> _logger;
        private readonly ICalculateService _calculateService;

        public CalculateInterestRateController(ILogger<CalculateInterestRateController> logger, ICalculateService calculateService)
        {
            _logger = logger;
            _calculateService = calculateService;
        }

        [HttpPost]
        public async Task<ActionResult<CalculateResponse>> InterestRateCalculated([FromQuery] decimal initialValue = 0, [FromQuery] int months = 0)
        {
            try
            {
                if (initialValue <= 0 || months <= 0)
                    return BadRequest("invalid data to calculate interest rate");

                var calculateResult = await _calculateService.GetCalculate(initialValue, months);

                if (calculateResult is null)
                    return NotFound("Unable calculate to Interest Rate");

                return Ok(new CalculateResponse((decimal)calculateResult));
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex, ex.Message);
                return Problem(ex.Message);
            }
        }
    }
}