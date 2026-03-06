using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application;

using var context = new LibraryContext();
var queryService = new QueryService(context);

await context.Database.MigrateAsync(); // Apparently gotta force it to run the migrations before seeding, otherwise seeding won't work.
await DbSeeder.SeedAsync(context);

// Log db seeding result to console 
Console.WriteLine($"Seeded {context.Books.Count()} books");
Console.WriteLine($"Seeded {context.Authors.Count()} authors");
Console.WriteLine($"Seeded {context.Borrowers.Count()} borrowers");
Console.WriteLine($"Seeded {context.Loans.Count()} loans");

// 3.1
Console.WriteLine("Loans with book title and borrower name:");
var loansWithBookAndBorrower = await queryService.GetLoansWBookTitleBorrowerName_IncludeSelect();
foreach(var loan in loansWithBookAndBorrower)
{
    Console.WriteLine($"Borrower: {loan.BorrowerName}, Book: {loan.BookTitle}");
}

// 3.2
Console.WriteLine("Author with amount of books");
var authorsBookCount = await queryService.GetAuthorsBookCount();
foreach(var author in authorsBookCount)
{
    Console.WriteLine($"Author: {author.AuthorName}, Book Count: {author.BookCount}");
}

// 3.3
var complexJoinResult = await queryService.GetLoansComplex_include();
Console.WriteLine($"Complex join results found: {complexJoinResult.Count()}");
foreach (var result in complexJoinResult)
{
    Console.WriteLine($"Borrower Name: {result.BorrowerName}, Book Title: {result.BookTitle}, Author Name: {result.AuthorName}, Rented: {result.LoanDate}, Return due: {result.ReturnDate}");
}

// 3.4 -- DOESNT WORK
Console.WriteLine("Book Title and Loan Count, only 2 or higher");
var filteredJoinResult = await queryService.FilteredJoin();
foreach(var result in filteredJoinResult)
{
    Console.WriteLine($"Book Title: {result.BookTitle}, Loan Count: {result.LoanCount}");
}