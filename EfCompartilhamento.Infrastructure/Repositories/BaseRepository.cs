using EfCompartilhamento.Domain.Entities;
using EfCompartilhamento.Domain.Repositories;
using EfCompartilhamento.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EfCompartilhamento.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
    {
        private readonly DbContext _context;

        protected BaseRepository(CompartilhamentoDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T? GetById(int id, bool shouldTrackEntity = true)
        {
            if (shouldTrackEntity)
            {
                return _context.Set<T>().Find(id);
            }
            else
            {
                return _context.Set<T>().AsNoTracking().FirstOrDefault(e => e.Id == id);
            }
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            T? entityToDelete = _context.Set<T>().Find(id);
            if (entityToDelete != null)
            {
                _context.Set<T>().Remove(entityToDelete);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}