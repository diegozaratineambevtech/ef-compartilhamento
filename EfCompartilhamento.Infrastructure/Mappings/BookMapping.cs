using EfCompartilhamento.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCompartilhamento.Infrastructure.Mapping
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("tb_books");
            builder.Property(b => b.Title).IsRequired().HasMaxLength(5);
            builder.HasIndex(b => b.Title);


        }
    }
}
