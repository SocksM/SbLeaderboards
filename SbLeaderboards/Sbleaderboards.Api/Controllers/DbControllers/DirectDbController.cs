using Microsoft.AspNetCore.Mvc;
using SbLeaderboards.Api.BLL.Services.DbServices;
using SbLeaderboards.Api.DAL.Configuration;
using SbLeaderboards.Api.DAL.Context;
using SbLeaderboards.Presentation.DAL.Repositories;
using SbLeaderboards.Resources.Interfaces;
using SbLeaderboards.Resources.Models;
using System.Dynamic;

namespace SbLeaderboards.Api.Controllers.DbControllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DirectDbController<E> : ControllerBase where E : Entity
	{
		protected readonly IDirectDbService<E> _directDbService;

		public DirectDbController(SbLeaderboardsContext sbLeaderboardsContext) : base()
		{
			_directDbService = new DirectDbService<E>(new DirectDbRepository<E>(sbLeaderboardsContext));
		}

		[HttpGet]
		virtual public IActionResult GetAll(bool includeChilderen = false, int page = 0)
		{
			try
			{
				List<E> entities = _directDbService.GetAll(includeChilderen);

				if (entities.Count == 0) return NotFound();

				int pageSize = 50;
				int totalCount = entities.Count;
				int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

				List<E> paginatedEntities = entities
					.Skip(page * pageSize)
					.Take(pageSize)
					.ToList();

				dynamic output = new ExpandoObject();
				output.page = page;
				output.totalPages = totalPages;
				output.totalCount = totalCount;
				output.entities = paginatedEntities;

				return Ok(output);
			}
			catch (Exception)
			{
				return Problem();
			}
		}

		[HttpGet("{id}")]
		virtual public IActionResult Get(int id, bool includeChilderen = true)
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