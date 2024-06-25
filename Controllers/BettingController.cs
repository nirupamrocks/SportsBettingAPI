using Microsoft.AspNetCore.Mvc;
using SportsBettingAPI.Models;
using SportsBettingAPI.Services;
using System.Threading.Tasks;

namespace SportsBettingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BettingController : ControllerBase
    {
        private readonly BettingOddsService _bettingOddsService;

        public BettingController(BettingOddsService bettingOddsService)
        {
            _bettingOddsService = bettingOddsService;
        }

        [HttpGet("mlb/odds")]
        public async Task<ActionResult<BetOnlineOdds>> GetMLBOdds()
        {
            var odds = await _bettingOddsService.GetBetOnlineMLBOddsAsync();
            return Ok(odds);
        }

        [HttpGet("pinnacle/mlb/odds")]
        public async Task<ActionResult<PinnacleOdds>> GetPinnacleMLBOdds()
        {
            var odds = await _bettingOddsService.GetPinnacleMLBOddsAsync();
            return Ok(odds);
        }
    }
}
