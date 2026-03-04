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

        public async Task<List<Loan>> GetAllActiveLoans() // Trying to just get used to working with async ASAP
        {
            return await _context.Loans
                .Include(x => x.Borrower)
                .Include(x => x.Book)
                .Where(x => x.ReturnDate == null)
                .ToListAsync();
        }
    }
}
