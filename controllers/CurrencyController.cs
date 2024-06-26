using CurrencyExchangeApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchangeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ExchangeRateService _exchangeRateService;
        public CurrencyController(ExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        [HttpGet("usd-to-try")]
        public async Task<IActionResult> GetUsdToTryRate()
        {
            var rate = await _exchangeRateService.GetUsdToTryExchangeRateAsync();
            return Ok(new { USD_TO_TRY = rate });
        }
    }
}