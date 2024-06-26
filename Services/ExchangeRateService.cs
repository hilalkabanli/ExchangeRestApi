using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CurrencyExchangeApi.Services
{
    public class ExchangeRateService
    {
        private readonly HttpClient _httpClient;

        public ExchangeRateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<decimal> GetUsdToTryExchangeRateAsync()
        {
            var response = await _httpClient.GetStringAsync("https://api.exchangerate-api.com/v4/latest/USD");
            var data = Newtonsoft.Json.Linq.JObject.Parse(response);
            var rates = data["rates"];
            if (rates != null)
            {
                var tryRate = rates["TRY"];
                if (tryRate != null)
                {
                    return tryRate.Value<decimal>();
                }
            }
            return 0m;
        }
    }
}