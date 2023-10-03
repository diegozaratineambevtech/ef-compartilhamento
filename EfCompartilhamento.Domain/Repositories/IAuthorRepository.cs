using EfCompartilhamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCompartilhamento.Domain.Repositories
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        public Author? GetWithBooks(int id);
    }
}
