using SbLeaderboards.Resources.Enums;

namespace SbLeaderboards.Api.ApiModels
{
	public class Profile : Entity
	{
		public ProfileType ProfileType { get; set; }
		public ProfileCuteName CuteName { get; set; }
		public Guid ProfileId { get; set; }
		public List<Stats>? Stats { get; set; }
	}
}