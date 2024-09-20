namespace SbLeaderboards.Resources.Models
{
	public class Player : Entity
	{
        public Guid McUuid { get; set; }
		public List<Stats> StatList { get; set; }
    }
}
