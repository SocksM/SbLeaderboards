namespace SbLeaderboards.Resources.Models
{
	public class Profile : Entity
	{
		public int PlayerId { get; set; }
		public Enums.ProfileType ProfileType { get; set; }
	}
}
