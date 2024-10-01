using Microsoft.AspNetCore.Mvc;

namespace SbLeaderboards.Api.Controllers
{
	public class LeaderboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
