using SbLeaderboards.Resources.DTOs;

namespace SbLeaderboards.Resources.Interfaces.IRepository
{
	public interface IRepository<E> where E : Entity
	{
		public void Create(E entity);
		public void Delete(E entity);
		public void Update(E entity);
		public List<E> GetAll();
		public E GetById(int id);
	}
}
