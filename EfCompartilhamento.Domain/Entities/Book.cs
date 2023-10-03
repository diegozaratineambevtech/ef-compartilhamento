namespace EfCompartilhamento.Domain.Entities
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<Author> Authors { get; set; } = new();
    }
}