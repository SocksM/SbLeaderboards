using SbLeaderboards.Resources.Models;

namespace SbLeaderboards.Resources.Interfaces.IRepository
{
	public interface IPlayerRepository : IDirectDbRepository<Player>
	{
		public Player GetByMcUuid(Guid McUuid, bool getChilderen = false);
	}
}
