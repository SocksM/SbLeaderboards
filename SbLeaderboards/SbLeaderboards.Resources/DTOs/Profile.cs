namespace SbLeaderboards.Resources.DTOs
{
	public class Profile : Entity
	{
		public int PlayerId { get; set; }
		public Enums.ProfileType ProfileType { get; set; }
		public Guid ProfileId { get; set; }

		public Profile() { }

		public Profile(Models.Profile profile) : base()
		{
			base.Id = profile.Id;
			ProfileType = profile.ProfileType;
			ProfileId = profile.ProfileId;
		}
	}
}