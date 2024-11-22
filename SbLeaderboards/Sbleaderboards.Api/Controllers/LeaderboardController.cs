using Microsoft.AspNetCore.Mvc;
using SbLeaderboards.Api.BLL.Services;
using SbLeaderboards.Api.DAL.ApiRepositories;
using SbLeaderboards.Api.DAL.Configuration;
using SbLeaderboards.Api.DAL.Context;
using SbLeaderboards.Api.DAL.Repositories;
using SbLeaderboards.Resources.Enums;
using System.Dynamic;

namespace SbLeaderboards.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {
        private readonly LeaderboardService _leaderboardService;

        //private readonly AppConfiguration _appConfiguration;

        public LeaderboardController(AppConfiguration appConfiguration, SbLeaderboardsContext sbLeaderboardsContext) : base()
        {
            //_appConfiguration = appConfiguration;
            _leaderboardService = new LeaderboardService(new PlayerRepository(sbLeaderboardsContext), new ProfileRepository(sbLeaderboardsContext), new MojangApiRepository(), new HypixelApiRepository(appConfiguration));
        }

        [HttpGet]
        public IActionResult Get(StatType statType = StatType.SkyblockExp, bool descending = true, int page = 0)
        {
            try
            {
                List<dynamic> leaderboard = _leaderboardService.Get(statType, descending);

                if (leaderboard == null || leaderboard.Count == 0) return NotFound();

                int pageSize = 50;
                int totalCount = leaderboard.Count;
                int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                List<dynamic> paginatedLeaderboard = leaderboard
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();

                dynamic output = new ExpandoObject();
                output.page = page;
                output.totalPages = totalPages;
                output.totalCount = totalCount;
                output.leaderboard = paginatedLeaderboard;

                return Ok(output);
            }
            catch (Exception ex)
            {
                return Problem();
                //return Ok(ex.Message +"::::::::::"+ _appConfiguration.GetApiKey("Hypixel") + "::::::::::" + _appConfiguration.GetDeploymentKey());
            }
        }
    }
}
