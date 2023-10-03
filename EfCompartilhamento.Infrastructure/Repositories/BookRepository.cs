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
        public BookRepository(CompartilhamentoDbContext context) : base(context)
        {
        }

    }
}
