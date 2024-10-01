using Microsoft.AspNetCore.Mvc;
using SbLeaderboards.Api.BLL.Services.DbServices;
using SbLeaderboards.Api.DAL.Configuration;
using SbLeaderboards.Api.DAL.Context;
using SbLeaderboards.Api.DAL.Repositories;
using SbLeaderboards.Resources.Models;
using SbLeaderboards.Resources.Enums;
using SbLeaderboards.Api.DAL.ApiRepositories;

namespace SbLeaderboards.Api.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class PlayerController : ControllerBase
	{
		private readonly PlayerService _playerService;

		public PlayerController(IConfiguration configuration) : base()
		{
			_playerService = new PlayerService(new PlayerRepository(new SbLeaderboardsContext(new AppConfiguration(configuration))), new MojangApiRepository());
		}

		[HttpGet]
		public IActionResult GetAll(bool includeChilderen = false)
		{
			try
			{
				var players = _playerService.GetAll(includeChilderen);

				if (players.Count == 0) return NotFound();

				return Ok(players);
			}
			catch (Exception)
			{
				return Problem();
			}
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id, bool includeChilderen = true)
		{
			try
			{
				var player = _playerService.GetById(id, includeChilderen);

				if (player == null) return NotFound();

				return Ok(player);
			}
			catch (Exception)
			{
				return Problem();
			}

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