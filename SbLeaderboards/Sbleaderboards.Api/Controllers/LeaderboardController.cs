using Microsoft.AspNetCore.Mvc;
using SbLeaderboards.Api.BLL.Services;
using SbLeaderboards.Api.DAL.ApiRepositories;
using SbLeaderboards.Api.DAL.Configuration;
using SbLeaderboards.Api.DAL.Context;
using SbLeaderboards.Api.DAL.Repositories;
using SbLeaderboards.Resources.Enums;
using SbLeaderboards.Resources.Models;
using System.Dynamic;

namespace SbLeaderboards.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LeaderboardController : ControllerBase
	{
		protected readonly LeaderboardService _leaderboardService;

		public LeaderboardController(IConfiguration configuration) : base()
		{
			_leaderboardService = new LeaderboardService(new ProfileRepository(new SbLeaderboardsContext(new AppConfiguration(configuration))), new PlayerRepository(new SbLeaderboardsContext(new AppConfiguration(configuration))), new MojangApiRepository());
		}

		[HttpGet]
		public IActionResult Get(StatType statType = StatType.SkyblockExp)
		{
			try
			{
				List<dynamic> leaderboard = _leaderboardService.Get(statType);

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
