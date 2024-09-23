using SbLeaderboards.Resources.DTOs;
using SbLeaderboards.Resources.Enums;

namespace SbLeaderboards.Resources.Interfaces.IRepository
{
	public interface IStatsRepository : IDirectDbRepository<Stats>
	{
		public List<Stats> GetByPlayerId(int playerId);
	}

}
