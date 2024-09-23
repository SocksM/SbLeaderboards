using SbLeaderboards.Resources.DTOs;

namespace SbLeaderboards.Resources.Interfaces.IRepository
{
	public interface IPlayerRepository : IDirectDbRepository<Player>
	{
		public Player GetByMcUuid(Guid McUuid);
		public KeyValuePair<bool, Player> UpdateName(Player player, TimeSpan? requiredWait);
	}
}
