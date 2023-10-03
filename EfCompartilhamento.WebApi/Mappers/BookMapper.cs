using EfCompartilhamento.Domain.Entities;
using EfCompartilhamento.WebApi.Dtos;

namespace EfCompartilhamento.WebApi.Mappers
{
    public static class BookMapper
    {
        public static BookDto MapToDto(Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
            };
        }

        public static Book MapToEntity(BookDto bookDto, int? id = null)
        {
            return new Book
            {
                Id = id is not null ? id.Value : 0,
                Title = bookDto.Title
            };
        }
    }
}