using SbLeaderboards.Resources.Interfaces;
using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.Models;

namespace SbLeaderboards.Api.BLL.Services.DbServices
{
	public class DirectDbService<E> : IDirectDbService<E> where E : Entity
	{
		private readonly IDirectDbRepository<E> _repository;

		public DirectDbService(IDirectDbRepository<E> repository)
		{
			_repository = repository;
		}

		public void Create(E entity)
		{
			_repository.Create(entity);
		}

		public void Delete(E entity)
		{
			_repository.Delete(entity);
		}

		public List<E> GetAll(bool includeChilderen = false)
		{
			return _repository.GetAll(includeChilderen);
		}

		public E GetById(int id, bool includeChilderen = true)
		{
			return _repository.GetById(id, includeChilderen);
		}

		public List<E> GetWhere(Func<E, bool> where, bool includeChilderen = false)
		{
			return _repository.GetWhere(where, includeChilderen);
		}

		public void Update(E entity)
		{
			_repository.Update(entity);
		}
	}
}
