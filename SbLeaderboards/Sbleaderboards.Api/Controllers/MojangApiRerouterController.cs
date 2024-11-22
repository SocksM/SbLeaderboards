﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SbLeaderboards.Api.BLL.Services;
using SbLeaderboards.Api.BLL.Services.DbServices;
using SbLeaderboards.Api.DAL.ApiRepositories;
using SbLeaderboards.Api.DAL.Configuration;
using SbLeaderboards.Resources.Models;

namespace SbLeaderboards.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MojangApiRerouterController : ControllerBase
	{
		private readonly MojangApiService _mojangApiService;
		private readonly AppConfiguration _configuration;
        public MojangApiRerouterController(AppConfiguration appConfiguration)
        {
			_mojangApiService = new MojangApiService(new MojangApiRepository());
        }

        [HttpGet("Player/McUuid/{name}")]
		public IActionResult GetMinecraftUUID(string name)
		{
			try
			{
				Guid guid = _mojangApiService.GetMcUuidByName(name);

				if (guid.Equals(Guid.Empty)) return NotFound();

				return Ok(guid);
			}
			catch (Exception)
			{
				return Problem();
			}
		}
	}
}
