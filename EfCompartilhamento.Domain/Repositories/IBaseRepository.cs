using EfCompartilhamento.Domain.Entities;

namespace EfCompartilhamento.Domain.Repositories
{
    public interface IBaseRepository<T> where T : class, IEntity
    {
        void Delete(int id);
        IQueryable<T> GetAll();
        T? GetById(int id, bool shouldTrackEntity = true);
        void Insert(T entity);
        void Save();
        void Update(T entity);
    }
}