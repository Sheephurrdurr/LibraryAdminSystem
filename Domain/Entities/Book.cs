using System;
using System.Collections.Generic;
using System.Text;
using Domain.Common;

namespace Domain.Entities
{
    public class Book
    {
        public Guid Id { get; private set; }
        public int ISBN { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int PublishingYear { get; private set; }
        public int PagesAmount  { get; private set; }
        public string Genre { get; private set; }
        public ICollection<Author> Author { get; private set; } = new List<Author>();
        public ICollection<Loan> Loans { get; private set; } = new List<Loan>();
        public bool IsAvailable => !Loans.Any(l => l.ReturnDate >= DateTime.Now); // A book is available if it doesnt have active loans (loans with return date in the future)

        private Book() { } // For EF Core   
        public Book(int isbn, string title, string description, int publishingYear, int pagesAmount, string genre, List<Author> authors)
        {
            Id = Guid.NewGuid();
            ISBN = Guard.ValidatePositive(isbn, nameof(ISBN)); // Guard handles validation for positive integers and non-empty strings. See /common
            Title = Guard.ValidateNotEmpty(title, nameof(Title));
            Description = Guard.ValidateNotEmpty(description, nameof(Description));
            PublishingYear = Guard.ValidatePositive(publishingYear, nameof(PublishingYear));
            PagesAmount = Guard.ValidatePositive(pagesAmount, nameof(PagesAmount));
            Genre = Guard.ValidateNotEmpty(genre, nameof(Genre));
            Author = Guard.NotNull(authors, nameof(authors));
        }


    }
}
