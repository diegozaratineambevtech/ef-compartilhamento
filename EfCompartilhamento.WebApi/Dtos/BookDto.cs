using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace EfCompartilhamento.WebApi.Dtos
{
    public class BookDto
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
