using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ILoanRepository
    {
        Task CreateLoan(Borrower borrower, Book book, DateTime loanDate);
        Task<Loan>? GetById(Guid id);
    }
}
