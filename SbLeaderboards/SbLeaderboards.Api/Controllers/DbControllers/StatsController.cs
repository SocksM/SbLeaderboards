using Microsoft.AspNetCore.Mvc;
using SbLeaderboards.Api.BLL.Services.DbServices;
using SbLeaderboards.Api.DAL.Configuration;
using SbLeaderboards.Api.DAL.Context;
using SbLeaderboards.Api.DAL.Repositories;
using SbLeaderboards.Resources.Models;

namespace SbLeaderboards.Api.Controllers.DbControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : DirectDbController<Stats>
    {
        public StatsController(SbLeaderboardsContext sbLeaderboardsContext) : base(sbLeaderboardsContext)
        {
        }
    }
}
