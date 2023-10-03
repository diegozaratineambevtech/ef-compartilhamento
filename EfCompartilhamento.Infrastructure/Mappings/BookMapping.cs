using EfCompartilhamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCompartilhamento.Infrastructure.Mapping
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("tb_books");
            builder.Property(b => b.Title).HasMaxLength(250);
            builder.HasIndex(b => b.Title);
        }
    }
}