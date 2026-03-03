using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Book
    {
        public Guid Id { get; private set; }
        public int ISBN { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int PagesAmount  { get; private set; }
        public string Genre { get; private set; }
        public Borrower Borrower { get; private set; }
        public ICollection<Author> Author { get; private set; } = new List<Author>();


        public Book(int isbn, string title, string description, int pagesAmount, string genre, Borrower borrower, List<Author> authors)
        {
           
        }

        public void ValidateIsbn()
        {
            if (ISBN <= 0)
            {
                throw new InvalidOperationException("ISBN must be a positive integer.");
            }
        }
        
        public void ValidatePagesAmount()
        {
            if (PagesAmount <= 0)
            {
                throw new InvalidOperationException("Pages amount must be above 0.");
            }
        }

        public void ValidateTitle()
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                throw new InvalidOperationException("Title cannot be empty.");
            }
        }
         public void ValidateGenre()
        {
            if (string.IsNullOrWhiteSpace(Genre))
            {
                throw new InvalidOperationException("Genre cannot be empty.");
            }
        }   

    }
}
