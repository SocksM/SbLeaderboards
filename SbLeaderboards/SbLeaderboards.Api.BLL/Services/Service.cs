using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.DTOs;

namespace SbLeaderboards.Api.BLL.Services
{
	public class Service<E> where E : Entity
	{
        private readonly IRepository<E> _repository;

        public Service(IRepository<E> repository)
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

        public List<E> GetAll()
        {
            return _repository.GetAll();
        }

        public E GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(E entity)
        {
            _repository.Update(entity);
        }
    }
}
