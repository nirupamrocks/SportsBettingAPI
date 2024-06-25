using Newtonsoft.Json;
using SportsBettingAPI.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SportsBettingAPI.Services
{
    public class BettingOddsService
    {
        private readonly IHttpClientFactory _clientFactory;

        public BettingOddsService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<BetOnlineOdds> GetBetOnlineMLBOddsAsync()
        {
            var client = _clientFactory.CreateClient("BetOnline");
            var response = await client.GetAsync("mlb/odds");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BetOnlineOdds>(content);
        }

        public async Task<PinnacleOdds> GetPinnacleMLBOddsAsync()
        {
            var client = _clientFactory.CreateClient("Pinnacle");
            var response = await client.GetAsync("mlb/odds");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PinnacleOdds>(content);
        }
    }
}
