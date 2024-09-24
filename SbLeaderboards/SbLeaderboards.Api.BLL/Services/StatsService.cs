using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.DTOs;

namespace SbLeaderboards.Api.BLL.Services
{
	public class StatsService : DirectDbService<Stats>
	{
		private readonly IStatsRepository _statsRepository;
		public StatsService(IStatsRepository statsRepository) : base(statsRepository)
		{
			_statsRepository = statsRepository;
		}

		public List<Stats> GetByProfileId(int playerId)
		{
			return _statsRepository.GetByProfileId(playerId);
		}
	}
}