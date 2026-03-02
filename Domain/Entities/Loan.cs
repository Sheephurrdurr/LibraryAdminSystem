using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Loan
    {
        public Guid Id { get; private set; }
        public Borrower Borrower { get; private set; }
        public Book Book { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime ReturnDate { get; private set; }

        public Loan(Borrower borrower, Book book, DateTime loanDate, DateTime returnDate)
        {
            ValidateLoanDate();
            ValidateReturnDate();
            Borrower = borrower;
            Book = book;
            LoanDate = loanDate;
            ReturnDate = returnDate;
        }

        public void ValidateLoanDate()
        {
            if (LoanDate < DateTime.Now)
            {
                throw new InvalidOperationException("Loan date must be in the future.");
            }
        }

        public void ValidateReturnDate()
        {
            if (ReturnDate < LoanDate)
            {
                throw new InvalidOperationException("Return date must be after the loan date.");
            }
        }
    }
}
