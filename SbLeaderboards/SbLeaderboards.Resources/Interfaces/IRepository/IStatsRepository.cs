using SbLeaderboards.Resources.DTOs;
using SbLeaderboards.Resources.Enums;

namespace SbLeaderboards.Resources.Interfaces.IRepository
{
	public interface IStatsRepository : IRepository<Stats>
	{
		public List<Stats> GetByPlayerId(int playerId);
		public List<Stats> GetByPlayerIdAndProfileType(int playerId, ProfileType profileType);
	}

}
