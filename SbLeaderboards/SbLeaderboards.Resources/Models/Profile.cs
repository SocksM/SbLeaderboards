using SbLeaderboards.Resources.Enums;

namespace SbLeaderboards.Resources.Models
{
	public class Profile : Entity
	{
		public int PlayerId { get; set; }
		public ProfileType Type { get; set; }
		public ProfileCuteName CuteName { get; set; }
		public Guid ProfileId { get; set; }
		public List<Stats>? Stats { get; set; }
	}
}