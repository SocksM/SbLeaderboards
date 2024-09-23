using SbLeaderboards.Resources.DTOs;

namespace SbLeaderboards.Resources.Interfaces.IRepository
{
	public interface IProfileRepository : IDirectDbRepository<Profile>
	{
		public Profile GetByPlayerId(int id);
	}
}
