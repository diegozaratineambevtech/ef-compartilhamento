using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace EfCompartilhamento.WebApi.Dtos
{
    public class AuthorDto
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
