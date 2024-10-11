using Microsoft.AspNetCore.Mvc;
using SbLeaderboards.Api.BLL.Services.DbServices;
using SbLeaderboards.Api.DAL.Configuration;
using SbLeaderboards.Api.DAL.Context;
using SbLeaderboards.Presentation.DAL.Repositories;
using SbLeaderboards.Resources.Interfaces;
using SbLeaderboards.Resources.Models;

namespace SbLeaderboards.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DirectDbController<E> : ControllerBase where E : Entity
	{
		protected readonly IDirectDbService<E> _directDbService;

		public DirectDbController(IConfiguration configuration) : base()
		{
			_directDbService = new DirectDbService<E>(new DirectDbRepository<E>(new SbLeaderboardsContext(new AppConfiguration(configuration))));
		}

		[HttpGet]
		public IActionResult GetAll(bool includeChilderen = false, int page = 0)
		{
			int maxEntries = 100;
			try
			{
				List<E> entity = _directDbService.GetAll(includeChilderen);

				if (entity.Count == 0) return NotFound();

				return Ok(entity);
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
				E entity = _directDbService.GetById(id, includeChilderen);

				if (entity == null) return NotFound();

				return Ok(entity);
			}
			catch (Exception)
			{
				return Problem();
			}
		}
	}
}