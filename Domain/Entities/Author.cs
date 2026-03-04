using System;
using System.Collections.Generic;
using System.Text;
using Domain.ValueObjects;
using Domain.Common;

namespace Domain.Entities
{
    public class Author
    {
        public Guid Id { get; private set; }
        public FullName Name { get; private set; }
        public string Biography { get; private set; }
        public ICollection<Book> Books { get; private set; } = new List<Book>();

        private Author() { } // For EF Core 
        public Author(string firstName, string LastName, string biography) 
        {
            Id = Guid.NewGuid();
            Name = new FullName(firstName, LastName); // Validation happens in AuthorName
            Biography = Guard.ValidateNotEmpty(biography, nameof(biography));
        }

        public void UpdateBiography(string newBiography)
        {
            Biography = Guard.ValidateNotEmpty(newBiography, nameof(newBiography));
        }   

        public void AddBook(Book book)
        {
            Guard.NotNull(book, nameof(book));
            Books?.Add(book);
        }
    }
}
