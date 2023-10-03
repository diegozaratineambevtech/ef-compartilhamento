using EfCompartilhamento.Domain.Entities;
using EfCompartilhamento.Domain.Repositories;
using EfCompartilhamento.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EfCompartilhamento.Infrastructure.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        private readonly CompartilhamentoDbContext _context;
        public AuthorRepository(CompartilhamentoDbContext context) : base(context)
        {
            _context = context;
        }

        public Author? GetWithBooks(int id)
        {
            //incluir exemplo de print de querystring
              return _context.Set<Author>().Include(a=>a.Books).FirstOrDefault(a => a.Id == id);
        }
    }
}