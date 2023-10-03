using EfCompartilhamento.Domain.Entities;
using EfCompartilhamento.Domain.Repositories;
using EfCompartilhamento.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCompartilhamento.Infrastructure.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        private readonly CompartilhamentoDbContext _context;
        public BookRepository(CompartilhamentoDbContext context) : base(context)
        {
            _context = context;

        }
        public Book? GetWithAuthors(int id)
        {
            //incluir exemplo de print de querystring
            return _context.Set<Book>().Include(a => a.Authors).FirstOrDefault(a => a.Id == id);
        }
    }
}
