using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LibraryContext _context;

        public LoanRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task CreateLoan(Borrower borrower, Book book, DateTime loanDate) // Task is basically a promise that this method will eventually return a result (loan).
        {                                                                             // Run this task "asynchronously" (at the same time as x) on another thread. This is cool. But mostly for heavy db operations.
                                                                                      // In this case, we're just doing some async to flex.
            var loan = new Loan(borrower, book, loanDate);
            await _context.SaveChangesAsync();
            await _context.Loans.AddAsync(loan); // await the task of adding the loan to the database.
                                                 // async is really cool, cuz it allows other operations to continue while waiting for the db operation to finish
        }

        public async Task<Loan>? GetById(Guid id)
        {
            return await _context.Loans.FindAsync(id);
        }
    }
}
