using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.Intrinsics.X86;
using System.Text;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using static Application.QueryService;

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
            return await _context.Loans // Promise to return a list of loansm when the query is done
                .Where(x => !x.IsReturned)
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
                .Select(x => new { x.Name, x.Email }) // .Select selects only the properties that are ... selected... Select.
                .ToListAsync<object>(); // object is 'DTO' here. Bad option.
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
                .CountAsync(x => x.ReturnDate == null); // Counts - but in asyncronous. 
        }

        // Del 3
        public class LoanDto // Create and use DTO to hold the data we need, instead of holding it all in memory for no reason
        {
            public string BorrowerName { get; set; }
            public string BookTitle { get; set; }
        }
        public async Task<List<LoanDto>> GetLoansWBookTitleBorrowerName_IncludeSelect()
        {
            return await _context.Loans
                .AsNoTracking() // AsNoTracking to fix a runtime error. Not sure if this is the best solution, but it works.
                .Include(l => l.Book) // .Include gets the entire entity, which... nah. 
                .Include(l => l.Borrower)
                .Select(l => new LoanDto // Here we select only what we need from the included stuff. 
                {
                    BorrowerName = l.Borrower.Name.ToString(),
                    BookTitle = l.Book.Title,
                })
                .ToListAsync();
        }

        public async Task<List<LoanDto>> GetLoansWBookTitleBorrowerName_Join() // Interesting syntax, I hate it. 
        {
            return await (from loan in _context.Loans

                join book in _context.Books 
                    on loan.Book.Id 
                    equals book.Id

                join borrower in _context.Borrowers 
                    on loan.Borrower.Id 
                    equals borrower.Id

                select new LoanDto
                {
                    BorrowerName = borrower.Name.ToString(),
                    BookTitle = book.Title
                })
                .ToListAsync();
        }

        public class AuthorBooksDto
        {
            public string AuthorName { get; set; }
            public int BookCount { get; set; }
        }
        public async Task<List<AuthorBooksDto>> GetAuthorsBookCount()
        {
            return await _context.Authors
                .AsNoTracking()
                .Include(a => a.Books)

                .Select(a => new AuthorBooksDto
                {
                    AuthorName = a.Name.ToString(),
                    BookCount = a.Books.Count
                })
                .ToListAsync();
        }

        public class ComplexJoinDto
        {
            public string BorrowerName { get; set; }
            public string BookTitle { get; set; }
            public string AuthorName { get; set; }
            public DateTime LoanDate { get; set; }
            public DateTime ReturnDate { get; set; }
        }

        public async Task<List<ComplexJoinDto>> GetLoansComplex_join()
        {

            return await (from loan in _context.Loans
                          join book in _context.Books
                              on loan.Book.Id
                              equals book.Id

                          join borrower in _context.Borrowers
                              on loan.Borrower.Id
                              equals borrower.Id

                          join author in _context.Authors
                              on book.Id
                              equals author.Id
                              // this is not gonna work...
                          select new ComplexJoinDto
                          {
                              BorrowerName = borrower.Name.ToString(),
                              BookTitle = book.Title,
                              AuthorName = author.Name.ToString(),
                              LoanDate = loan.LoanDate,
                              ReturnDate = loan.ReturnDate
                          })

                          .AsNoTracking()
                          .ToListAsync();
        }
        
        public async Task<List<ComplexJoinDto>> GetLoansComplex_include()
        {
            return await _context.Loans
                .AsNoTracking()
                .Include(l => l.Book)
                    .ThenInclude(b => b.Author) // .ThenInclude is how you include a navigation property of a navigation property.
                .Include(l => l.Borrower)
                .Select(l => new ComplexJoinDto
                {
                    BorrowerName = l.Borrower.Name.ToString(),
                    BookTitle = l.Book.Title,
                    AuthorName = string.Join(", ", l.Book.Author.Select(a => a.Name)), // If a book has multiple authors, we join their names with a comma. So much for that many-to-many relation.
                    LoanDate = l.LoanDate,
                    ReturnDate = l.ReturnDate
                })
                .ToListAsync();
        }
        
    }
}
