namespace SbLeaderboards.Resources.Models
{
	public class Player : Entity
	{
		public string Name { get; set; }
        public Guid McUuid { get; set; }
		public DateTime lastNameCheck { get; set; }
		public List<Stats>? StatList { get; set; }

        public Player() : base() { }

        public Player(DTOs.Player player) : base()
        {
            base.Id = player.Id;
            Name = player.Name;
            McUuid = player.McUuid;
            lastNameCheck  = player.lastNameCheck;
        }
    }
}
