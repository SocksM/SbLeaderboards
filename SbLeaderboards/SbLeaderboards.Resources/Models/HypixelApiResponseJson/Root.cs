// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
namespace SbLeaderboards.Resources.Models.HypixelApiResponseJson
{
	public class Root
	{
		public bool success { get; set; }
		public Profile profile { get; set; } = null!;
	}
}