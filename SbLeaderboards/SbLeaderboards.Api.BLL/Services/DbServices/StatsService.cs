using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.Models;

namespace SbLeaderboards.Api.BLL.Services.DbServices
{
    public class StatsService : DirectDbService<Stats>
    {
        private readonly IStatsRepository _statsRepository;
        public StatsService(IStatsRepository statsRepository) : base(statsRepository)
        {
            _statsRepository = statsRepository;
        }
    }
}