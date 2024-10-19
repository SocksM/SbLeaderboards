using Microsoft.AspNetCore.Mvc;
using SbLeaderboards.Api.BLL.Services;
using SbLeaderboards.Api.DAL.ApiRepositories;
using SbLeaderboards.Api.DAL.Configuration;
using SbLeaderboards.Api.DAL.Context;
using SbLeaderboards.Api.DAL.Repositories;
using SbLeaderboards.Resources.Enums;

namespace SbLeaderboards.Api.Controllers.DbControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {
        protected readonly LeaderboardService _leaderboardService;

        public LeaderboardController(IConfiguration configuration) : base()
        {
            AppConfiguration appConfiguration = new AppConfiguration(configuration);
            SbLeaderboardsContext context = new SbLeaderboardsContext(appConfiguration);
            _leaderboardService = new LeaderboardService(new PlayerRepository(context), new ProfileRepository(context), new MojangApiRepository(), new HypixelApiRepository(appConfiguration));
        }

        [HttpGet]
        public IActionResult Get(StatType statType = StatType.SkyblockExp, bool descending = true)
        {
            try
            {
                List<dynamic> leaderboard = _leaderboardService.Get(statType, descending);

                if (leaderboard == null || leaderboard.Count == 0) return NotFound();

                return Ok(leaderboard);
            }
            catch (Exception)
            {
                return Problem();
            }
        }
    }
}
