using Microsoft.AspNetCore.Mvc;
using SbLeaderboards.Api.BLL.Services.DbServices;
using SbLeaderboards.Api.DAL.ApiRepositories;
using SbLeaderboards.Api.DAL.Configuration;
using SbLeaderboards.Api.DAL.Context;
using SbLeaderboards.Api.DAL.Repositories;
using SbLeaderboards.Resources.Models;

namespace SbLeaderboards.Api.Controllers.DbControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : DirectDbController<Player>
    {
        private readonly PlayerService _playerService;

        public PlayerController(AppConfiguration appConfiguration, SbLeaderboardsContext sbLeaderboardsContext) : base(sbLeaderboardsContext)
        {
            _playerService = (PlayerService)_directDbService;
        }

        [HttpGet("{id}")]
        public override IActionResult Get(int id, bool includeChilderen = true)
        {
            try
            {
                Player player = _playerService.GetById(id, includeChilderen);

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
                Player player = _playerService.GetByMcUuid(mcUuid, includeChilderen);

                if (player == null) return NotFound();

                return Ok(player);
            }
            catch (Exception)
            {
                return Problem();
            }

        }

		[HttpGet("StartTracking/{mcUuid}")]
		public IActionResult StartTracking(Guid mcUuid)
		{
			try
			{
				Player player = _playerService.StartTracking(mcUuid);

				if (player == null) return NotFound();

				return Ok(player);
			}
			catch (Exception ex)
			{
				return Problem();
			}

		}
	}
}