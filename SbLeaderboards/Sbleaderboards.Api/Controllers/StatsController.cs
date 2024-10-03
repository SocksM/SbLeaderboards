using Microsoft.AspNetCore.Mvc;
using SbLeaderboards.Api.BLL.Services.DbServices;
using SbLeaderboards.Api.DAL.Configuration;
using SbLeaderboards.Api.DAL.Context;
using SbLeaderboards.Api.DAL.Repositories;
using SbLeaderboards.Resources.Models;

namespace SbLeaderboards.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StatsController : DirectDbController<Stats>
	{
		private readonly StatsService _statsService;

		public StatsController(IConfiguration configuration) : base(configuration)
        {
			_statsService = new StatsService(new StatsRepository(new SbLeaderboardsContext(new AppConfiguration(configuration))));
		}
	}
}
