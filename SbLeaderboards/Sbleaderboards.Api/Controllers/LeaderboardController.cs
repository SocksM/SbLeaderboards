using Microsoft.AspNetCore.Mvc;
using SbLeaderboards.Api.BLL.Services;
using SbLeaderboards.Resources.DTOs;
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
			_leaderboardService = new LeaderboardService(configuration);
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
