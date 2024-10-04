using Microsoft.AspNetCore.Mvc;
using SbLeaderboards.Api.BLL.Services.DbServices;
using SbLeaderboards.Api.DAL.ApiRepositories;
using SbLeaderboards.Api.DAL.Configuration;
using SbLeaderboards.Api.DAL.Context;
using SbLeaderboards.Api.DAL.Repositories;
using SbLeaderboards.Resources.Models;

namespace SbLeaderboards.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlayerController : DirectDbController<Player>
	{
		private readonly PlayerService _playerService;

		public PlayerController(IConfiguration configuration) : base(configuration)
		{
			_playerService = new PlayerService(new PlayerRepository(new SbLeaderboardsContext(new AppConfiguration(configuration))), new MojangApiRepository());
		}

		[HttpGet("Mc{mcUuid}")]
		public IActionResult Get(Guid mcUuid, bool includeChilderen = true)
		{
			try
			{
				var player = _playerService.GetByMcUuid(mcUuid, includeChilderen);

				if (player == null) return NotFound();

				return Ok(player);
			}
			catch (Exception)
			{
				return Problem();
			}

		}
	}
}