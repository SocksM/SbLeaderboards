using SbLeaderboards.Resources.DTOs;

namespace SbLeaderboards.Resources.Interfaces.IRepository
{
	public interface IStatsRepository : IDirectDbRepository<Stats>
	{
		public List<Stats> GetByProfileId(int profileId);
	}

}
