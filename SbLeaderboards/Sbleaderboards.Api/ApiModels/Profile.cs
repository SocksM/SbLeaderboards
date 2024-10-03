using SbLeaderboards.Resources.Enums;

namespace SbLeaderboards.Api.ApiModels
{
	public class Profile : Entity
	{
		public ProfileType ProfileType { get; set; }
		public ProfileCuteName CuteName { get; set; }
		public Guid ProfileId { get; set; }
		public List<Stats>? Stats { get; set; }

        public Profile(Resources.Models.Profile profile) : base(new Resources.Models.Entity { Id = profile.Id })
		{
            ProfileType = profile.ProfileType;
			CuteName = profile.CuteName;
			ProfileId = profile.ProfileId;
			foreach (Resources.Models.Stats stats in profile.Stats) Stats.Add(new Stats(stats));
        }
    }
}