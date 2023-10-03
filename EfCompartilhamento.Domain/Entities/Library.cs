﻿namespace EfCompartilhamento.Domain.Entities
{
    public class Library : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Book> Books { get; set; } = new();
    }
}