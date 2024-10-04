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
	public class ProfileController : DirectDbController<Profile>
	{
		private readonly ProfileService _profileService;

		public ProfileController(IConfiguration configuration) : base(configuration)
		{
			_profileService = new ProfileService(new ProfileRepository(new SbLeaderboardsContext(new AppConfiguration(configuration))));

		}
	}
}
