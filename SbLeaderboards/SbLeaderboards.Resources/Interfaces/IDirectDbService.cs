using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.Models;

namespace SbLeaderboards.Resources.Interfaces
{
    public interface IDirectDbService<E> where E : Entity
    {
		public void Create(E entity);
		public void Delete(E entity);
		public List<E> GetAll(bool includeChilderen = false);
		public E GetById(int id, bool includeChilderen = true);
		public List<E> GetWhere(Func<E, bool> where, bool includeChilderen = false);
		public void Update(E entity);
	}
}
