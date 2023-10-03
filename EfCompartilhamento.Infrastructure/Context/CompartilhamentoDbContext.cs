using EfCompartilhamento.Domain.Entities;
using EfCompartilhamento.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCompartilhamento.Infrastructure.Context
{
    public class CompartilhamentoDbContext : DbContext
    {
        public CompartilhamentoDbContext(DbContextOptions<CompartilhamentoDbContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        //public DbSet<Library> Librarys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookMapping());

        }
    }
}
