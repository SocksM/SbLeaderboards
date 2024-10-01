using SbLeaderboards.Api.DAL.Context;
using SbLeaderboards.Presentation.DAL.Repositories;
using SbLeaderboards.Resources.Models;
using SbLeaderboards.Resources.Interfaces.IRepository;

namespace SbLeaderboards.Api.DAL.Repositories
{
	public class ProfileRepository : DirectDbRepository<Profile>, IProfileRepository
	{
		private readonly IStatsRepository _statsRepository;
		public ProfileRepository(SbLeaderboardsContext context) : base(context)
		{
			_statsRepository = new StatsRepository(context);
		}

		public List<Profile> GetAll(bool getChilderen = false)
		{
			List<Profile> profiles = base.GetAll();
			if (getChilderen) profiles = GetChilderen(profiles);
			return profiles;
		}

		public Profile GetById(int id, bool getChilderen = false)
		{
			Profile profile = base.GetById(id);
			if (getChilderen) profile = GetChilderen(profile);
			return profile;
		}

		public List<Profile> GetWhere(Func<Profile, bool> where, bool getChilderen = false)
		{
			List<Profile> profiles = base.GetWhere(where);
			if (getChilderen) profiles = GetChilderen(profiles);
			return profiles;
		}

		private List<Profile> GetChilderen(List<Profile> profiles)
		{
			throw new NotImplementedException();

			//List<Stats> stats = _statsRepository.GetWhere(stats => profiles.Select(profile => profile.Id).ToList().Contains(stats.ProfileId));
			//profiles = profiles.GroupJoin(stats, 
			//	profile => profile.Id, 
			//	stats => stats.ProfileId, 
			//	(profile, stats) => { profile.Stats.AddRange(stats); return profile; }
			//	).ToList();
			//return profiles;
		}

		private Profile GetChilderen(Profile profile)
		{
			throw new NotImplementedException();

			//profile.Stats = _statsRepository.GetByProfileId(profile.Id);
			//return profile;
		}
	}
}