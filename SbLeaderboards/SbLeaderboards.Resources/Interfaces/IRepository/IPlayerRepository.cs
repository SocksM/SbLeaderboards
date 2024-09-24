using SbLeaderboards.Resources.DTOs;

namespace SbLeaderboards.Resources.Interfaces.IRepository
{
	public interface IPlayerRepository : IDirectDbRepository<Player>
	{
		public Player GetByMcUuid(Guid McUuid, bool getChilderen = false);
		public KeyValuePair<bool, Player> UpdateName(Player player, TimeSpan? requiredWait);
	}
}
