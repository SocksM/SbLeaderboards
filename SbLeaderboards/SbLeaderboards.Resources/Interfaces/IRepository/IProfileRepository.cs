using SbLeaderboards.Resources.DTOs;

namespace SbLeaderboards.Resources.Interfaces.IRepository
{
	public interface IProfileRepository : IDirectDbRepository<Profile>
	{
		public Profile GetByPlayerId(int id, bool getChilderen);
		public List<Profile> GetAll(bool getChilderen = false);
		public Profile GetById(int id, bool getChilderen = false);
		public List<Profile> GetWhere(Func<Profile, bool> where, bool getChilderen = false);
	}
}
