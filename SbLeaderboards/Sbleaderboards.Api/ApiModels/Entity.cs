namespace SbLeaderboards.Api.ApiModels
{
	public class Entity
	{
		public int Id { get; set; }

        public Entity(Resources.Models.Entity entity)
        { 
            Id = entity.Id;
        }
    }
}