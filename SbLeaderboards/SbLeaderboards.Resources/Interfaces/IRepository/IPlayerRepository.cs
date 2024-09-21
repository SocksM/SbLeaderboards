using SbLeaderboards.Resources.DTOs;

namespace SbLeaderboards.Resources.Interfaces.IRepository
{
	public interface IPlayerRepository : IRepository<Player>
	{
		public Player GetByMcUuid(Guid McUuid);
	}
}
