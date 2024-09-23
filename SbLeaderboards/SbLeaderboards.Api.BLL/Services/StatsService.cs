using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.DTOs;
using SbLeaderboards.Resources.Enums;

namespace SbLeaderboards.Api.BLL.Services
{
	public class StatsService : DirectDbService<Stats>
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

		public List<Stats> GetHistory(int playerId, ProfileType? profileType = null, DateTime? fromDateTime = null, DateTime? toDateTime = null)
		{
			return _statsRepository.GetWhere(
				s => s.PlayerId == playerId &&
				(profileType == null || s.ProfileType == profileType) &&
				(fromDateTime == null || s.Timestamp >= fromDateTime) &&
				(toDateTime == null || s.Timestamp <= toDateTime))
				.ToList();
		}
	}
}