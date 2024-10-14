namespace SbLeaderboards.Resources.Models.HypixelApiResponseJson.V2_Skyblock_ProfileEndpoint
{
	public class member
	{
		public string player_id { get; set; }
		public player_data player_data { get; set; }
		public dungeons dungeons { get; set; }
		public leveling leveling { get; set; }
	}
}