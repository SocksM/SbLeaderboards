namespace SbLeaderboards.Resources.Models
{
	public class Player : Entity
	{
		public string Name { get; set; }
        public Guid McUuid { get; set; }
		public DateTime lastNameCheck { get; set; }
		public List<Stats> StatList { get; set; }
	}
}
