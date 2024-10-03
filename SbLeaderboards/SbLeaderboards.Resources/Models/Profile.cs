using SbLeaderboards.Resources.Enums;

namespace SbLeaderboards.Resources.Models
{
	public class Profile : Entity
	{
		public int PlayerId { get; set; }  // Foreign key
		public Player Player { get; set; } // Navigation property
		public ProfileType ProfileType { get; set; }
		public ProfileCuteName CuteName { get; set; }
		public Guid ProfileId { get; set; }
		public List<Stats>? Stats { get; set; }
	}
}