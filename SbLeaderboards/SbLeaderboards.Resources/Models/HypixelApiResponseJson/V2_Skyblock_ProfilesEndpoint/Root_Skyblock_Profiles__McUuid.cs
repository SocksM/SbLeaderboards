using SbLeaderboards.Resources.Models.HypixelApiResponseJson.V2_Skyblock_ProfileEndpoint;

namespace SbLeaderboards.Resources.Models.HypixelApiResponseJson.V2_Skyblock_ProfilesEndpoint
{
	public class Root_Skyblock_Profiles__McUuid
	{
		public bool success { get; set; }
		public List<profile> profiles { get; set; }
	}
}