using EfCompartilhamento.Domain.Entities;
using EfCompartilhamento.WebApi.Dtos;

namespace EfCompartilhamento.WebApi.Mappers
{
    public static class AuthorMapper
    {
        public static Author MapToEntity(AuthorDto authorDto, int? id = null)
        {
            return new Author
            {
                Id = id is not null ? id.Value : 0,
                Name = authorDto.Name
            };
        }

        public static AuthorDto MapToDto(Author author)
        {
            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name
            };
        }
    }
}
