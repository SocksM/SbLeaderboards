using Microsoft.AspNetCore.Mvc;
using SbLeaderboards.Api.BLL.Services.DbServices;
using SbLeaderboards.Api.DAL.Repositories;
using SbLeaderboards.Resources.Models;
using SbLeaderboards.Resources.Enums;

namespace SbLeaderboards.Api.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class LeaderboardController : ControllerBase
	{
		private readonly LeaderboardService _leaderboardService;
        public LeaderboardController(IConfiguration configuration) : base()
        {
			throw new NotImplementedException();
			//_leaderboardService = new LeaderboardService(new StatsService(new StatsRepository(new DAL.Context.SbLeaderboardsContext(new DAL.Configuration.AppConfiguration(configuration)))));
        }

        [HttpGet]
		public IActionResult Get(int page = 1, int pageSize = 50, bool allowMultipleProfiles = false, StatType Sort = StatType.SkyblockExp)
		{
			int maxPageSize = 200;
			if (pageSize > maxPageSize) pageSize = maxPageSize;

			try
			{
				List<Stats> stats = null;
				throw new NotImplementedException();
			}
			catch (Exception)
			{
				return Problem();
			}
		}
	}
}
