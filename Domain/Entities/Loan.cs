using System;
using System.Collections.Generic;
using System.Text;
using Domain.Common;

namespace Domain.Entities
{
    public class Loan
    {
        public Guid Id { get; private set; }
        public Borrower Borrower { get; private set; }
        public Book Book { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime ReturnDate { get; private set; }
        public bool IsOverdue => DateTime.Now > ReturnDate;

        private Loan() { } // For EF Core
        public Loan(Borrower borrower, Book book, DateTime loanDate)
        {
            Id = Guid.NewGuid();
            Borrower = Guard.NotNull(borrower, nameof(borrower));
            Book = Guard.NotNull(book, nameof(book));
            LoanDate = Guard.ValidateInFuture(loanDate, nameof(loanDate));
            ReturnDate = LoanDate.AddDays(14); // Is set when object is created, and never changed. IsOverdue is calculated based on this value, and the current date.
        }
        
        public void BorrowBook()
        {
            if (!Book.IsAvailable)
                throw new InvalidOperationException("Book is not available for borrowing.");
            
        }

        public void ReturnBook()
        {

        }

        public void ExtendLoan(int extraDays)
        {
            if (extraDays <= 0)
                throw new ArgumentException("Extra days must be greater than zero.", nameof(extraDays));

            if (IsOverdue)
                throw new InvalidOperationException("Cannot extend an overdue loan.");

            if (extraDays > 30)
                throw new ArgumentException("Cannot extend loan for more than 30 days.", nameof(extraDays));

            ReturnDate = ReturnDate.AddDays(extraDays);
        }


    }
}
