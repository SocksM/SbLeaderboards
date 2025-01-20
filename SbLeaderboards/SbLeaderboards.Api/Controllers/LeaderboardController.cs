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

        public LeaderboardController(AppConfiguration appConfiguration, SbLeaderboardsContext sbLeaderboardsContext) : base()
        {
            _leaderboardService = new LeaderboardService(new PlayerRepository(sbLeaderboardsContext), new ProfileRepository(sbLeaderboardsContext), new MojangApiRepository(), new HypixelApiRepository(appConfiguration));
        }

        [HttpGet] 
        public IActionResult Get(StatType statType = StatType.SkyblockExp, bool descending = true, int page = 0)
		// I am aware that this is not the best way to handle pagination,
        // but doing it differently would require me to write sql queries which I would rather avoid since I think it would be out of scope for this project.
        // Also I would like to showcase my c# skills and not my sql skills.
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
            }
        }
    }
}
