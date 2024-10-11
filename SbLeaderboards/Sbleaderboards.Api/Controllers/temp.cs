using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SbLeaderboards.Api.BLL.Services;
using SbLeaderboards.Api.DAL.ApiRepositories;

namespace SbLeaderboards.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class temp : ControllerBase
	{
		[HttpGet]
		public IActionResult Get(Guid guid)
		{
			HypixelApiService service = new HypixelApiService(new HypixelApiRepository("9fe789fd-fab6-47ef-a4e5-625d133ea823"));
			return Ok(service.GetProfileByProfileUuid(guid));
		}
	}
}
