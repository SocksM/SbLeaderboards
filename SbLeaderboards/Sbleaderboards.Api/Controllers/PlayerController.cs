using Microsoft.AspNetCore.Mvc;
using SbLeaderboards.Api.BLL.Services;
using SbLeaderboards.Api.DAL.Configuration;
using SbLeaderboards.Api.DAL.Context;
using SbLeaderboards.Api.DAL.Repositories;
using SbLeaderboards.Resources.DTOs;
using SbLeaderboards.Resources.Enums;

namespace SbLeaderboards.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlayerController : ControllerBase
	{
		private readonly PlayerService _playerService;
		private readonly StatsService _statsService;

		public PlayerController(IConfiguration configuration) : base()
		{
			_playerService = new PlayerService(new PlayerRepository(new SbLeaderboardsContext(new AppConfiguration(configuration))));
			_statsService = new StatsService(new StatsRepository(new SbLeaderboardsContext(new AppConfiguration(configuration))));
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			try
			{
				var players = _playerService.GetAll();

				if (players == null) return NotFound();

				return Ok(players);
			}
			catch (Exception)
			{
				return Problem();
			}
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			try
			{
				var player = _playerService.GetById(id);

				if (player == null) return NotFound();

				return Ok(player);
			}
			catch (Exception)
			{
				return Problem();
			}

		}

		[HttpGet("Mc{mcUuid}")]
		public IActionResult Get(Guid mcUuid)
		{
			try
			{
				var player = _playerService.GetByMcUuid(mcUuid);

				if (player == null) return NotFound();

				return Ok(player);
			}
			catch (Exception)
			{
				return Problem();
			}

		}

		[HttpGet("{id}/History")]
		public IActionResult GetHistory(int id, ProfileType? profileType = null, DateTime? fromDateTime = null, DateTime? toDateTime = null)
		{
			try
			{
				List<Stats> stats = _statsService.GetHistory(id, profileType, fromDateTime, toDateTime);

				if (stats == null || !stats.Any()) return NotFound();

				return Ok(stats);
			}
			catch (Exception)
			{
				return Problem();
			}
		}


		[HttpGet("Mc{mcUuid}/History")]
		public IActionResult GetHistory(Guid mcUuid, ProfileType? profileType = null, DateTime? fromDateTime = null, DateTime? toDateTime = null)
		{
			try
			{
				Player player = _playerService.GetByMcUuid(mcUuid);

				List<Stats> stats = _statsService.GetHistory(player.Id, profileType, fromDateTime, toDateTime);

				if (stats == null || !stats.Any()) return NotFound();

				return Ok(stats);
			}
			catch (Exception)
			{
				return Problem();
			}
		}
	}
}