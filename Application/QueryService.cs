using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public class QueryService
    {
        private readonly LibraryContext _context;
        public QueryService(LibraryContext context)
        {
            _context = context;
        }

        // Del 2
        public async Task<List<Loan>> GetAllActiveLoans() // Trying to just get used to working with async ASAP
        {
            return await _context.Loans
                .Where(x => x.ReturnDate == null)
                .ToListAsync();
        }
        
        public async Task<List<Book>> SortBooksByPublishingYear()
        {
            return await _context.Books
                .OrderByDescending(x => x.PublishingYear)
                .ToListAsync();
        }

        public async Task<List<object>> ShowBorrowerNameEmail() // Should've probably, maybe, perhaps made a DTO for this. But in my defense: I didn't want to. 
        {
            return await _context.Borrowers
                .Select(x => new { x.Name, x.Email })
                .ToListAsync<object>(); // object is DTO here. I just didnt create it explicitly.. or something to that effect.
        }

        public async Task<List<Book>> GetAllBooksNamedHarry()
        {
            return await _context.Books
                .Where(x => x.Title.Contains("Harry"))
                .ToListAsync();
        }

        public async Task<int> CountActiveLoans()
        {
            return await _context.Loans
                .CountAsync(x => x.ReturnDate == null);
        }

        // Del 3
        public class LoanDto
        {
            public string BorrowerName { get; set; }
            public string BookTitle { get; set; }
        }
        public async Task<List<LoanDto>> GetLoansWBookTitleBorrowerName()
        {
            return await _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Borrower)
                .Select(l => new LoanDto
                {
                    BorrowerName = l.Borrower.Name.ToString(),
                    BookTitle = l.Book.Title,

                })
                .ToListAsync();
        }
    }
}
