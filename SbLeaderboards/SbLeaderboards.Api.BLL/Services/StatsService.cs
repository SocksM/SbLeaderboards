using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.DTOs;
using SbLeaderboards.Resources.Enums;

namespace SbLeaderboards.Api.BLL.Services
{
	public class StatsService : Service<Stats>
	{
		private readonly IStatsRepository _statsRepository;
		public StatsService(IStatsRepository statsRepository) : base(statsRepository)
		{
			_statsRepository = statsRepository;
		}

		public List<Stats> GetByPlayerId(int playerId)
		{
			return _statsRepository.GetByPlayerId(playerId);
		}

		public List<Stats> GetByPlayerIdAndProfileType(int playerId, ProfileType profileType)
		{
			return _statsRepository.GetByPlayerIdAndProfileType(playerId, profileType);
		}
	}
}
