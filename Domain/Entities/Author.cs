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
        public string Nationality { get; private set; }
        public int YearOfBirth { get; private set; }
        public string Biography { get; private set; }
        public readonly List< Book> _books = new List<Book>();
        public IReadOnlyList<Book> Books => _books.AsReadOnly(); // Encapsulation, bro. Normal list can just be accessed and modified from outside, which we dont want. Even with private set.

        private Author() { } //empty constructor for EFCore 
        public Author(string firstName, string LastName, string biography) 
        {
            Id = Guid.NewGuid();
            Name = new FullName(firstName, LastName); // Validation happens in AuthorName (Value Object)
            Biography = Guard.ValidateNotEmpty(biography, nameof(biography));
        }

        public void UpdateBiography(string newBiography)
        {
            Biography = Guard.ValidateNotEmpty(newBiography, nameof(newBiography));
        }   

        public void AddBook(Book book)
        {
            Guard.NotNull(book, nameof(book));
            _books?.Add(book); // Use the private list to add the book, IReadOnlyList is just to view the contents
        }
    }
}
