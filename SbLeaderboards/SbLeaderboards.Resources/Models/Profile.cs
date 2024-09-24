namespace SbLeaderboards.Resources.Models
{
	public class Profile : Entity
	{
		public int PlayerId { get; set; }
		public Enums.ProfileType ProfileType { get; set; }
		public Guid ProfileId { get; set; }
		public List<Stats>? Stats { get; set; }

		public Profile() { }

		public Profile(DTOs.Profile profile) : base()
		{
			base.Id = profile.Id;
			ProfileType = profile.ProfileType;
			ProfileId = profile.ProfileId;
		}
	}
}
