using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DbSeeder
    {
        public static async Task SeedAsync(LibraryContext context)
        {
            if (!context.Authors.Any()) // If there are any Authors already in the db, then dont do anything
            {
                var author1 = new Author("F. Scott", "Fitzgerald", 1896, "American", "American novelist and short story writer");
                var author2 = new Author("Jane", "Austen", 1775, "British", "English novelist known for her social commentary");
                var author3 = new Author("George", "Orwell", 1903, "British", "English novelist and essayist, known for his critiques of totalitarianism");
                var author4 = new Author("Ernest", "Hemingway", 1899, "American", "American novelist and Nobel Prize winner known for his minimalist style");
                var author5 = new Author("Virginia", "Woolf", 1882, "British", "English writer and modernist pioneer");

                var authors = new List<Author> { author1, author2, author3, author4, author5 };

                context.Authors.AddRange(authors);
                await context.SaveChangesAsync();
            }


            if (!context.Books.Any())
            {

                var author1 = context.Authors.FirstOrDefault(a => a.Name.FirstName == "F. Scott" && a.Name.LastName == "Fitzgerald"); // Retrieve the author from context to associate with the book
                var author2 = context.Authors.FirstOrDefault(a => a.Name.FirstName == "Jane" && a.Name.LastName == "Austen");
                var author3 = context.Authors.FirstOrDefault(a => a.Name.FirstName == "George" && a.Name.LastName == "Orwell");
                var author4 = context.Authors.FirstOrDefault(a => a.Name.FirstName == "Ernest" && a.Name.LastName == "Hemingway");
                var author5 = context.Authors.FirstOrDefault(a => a.Name.FirstName == "Virginia" && a.Name.LastName == "Woolf");

                var book1 = new Book(11111, "The Great Gatsby", "A story of the fabulously wealthy Jay Gatsby", 1925, 180, "Fiction", new List<Author> { author1 });
                var book2 = new Book(22222, "Tender Is the Night", "A psychological novel set on the French Riviera", 1934, 320, "Fiction", new List<Author> { author1 });
                var book3 = new Book(33333, "Pride and Prejudice", "A romantic novel following Elizabeth Bennet", 1813, 432, "Romance", new List<Author> { author2 });
                var book4 = new Book(44444, "Sense and Sensibility", "A story of the Dashwood sisters navigating love and society", 1811, 368, "Romance", new List<Author> { author2 });
                var book5 = new Book(55555, "Emma", "A comedy of manners following the well-meaning but misguided Emma Woodhouse", 1815, 400, "Romance", new List<Author> { author2 });
                var book6 = new Book(66666, "1984", "A dystopian novel set in a totalitarian society under Big Brother", 1949, 328, "Dystopian", new List<Author> { author3 });
                var book7 = new Book(77777, "Animal Farm", "An allegorical novella reflecting events leading up to the Russian Revolution", 1945, 112, "Satire", new List<Author> { author3 });
                var book8 = new Book(88888, "The Old Man and the Sea", "An aging fisherman struggles with a giant marlin far out in the Gulf Stream", 1952, 127, "Fiction", new List<Author> { author4 });
                var book9 = new Book(99999, "A Farewell to Arms", "A love story set against the backdrop of World War I", 1929, 332, "Historical Fiction", new List<Author> { author4 });
                var book10 = new Book(10101, "For Whom the Bell Tolls", "An American fights with Republican guerrillas in the Spanish Civil War", 1940, 480, "Historical Fiction", new List<Author> { author4 });
                var book11 = new Book(11011, "Mrs Dalloway", "A day in the life of Clarissa Dalloway in post-World War I England", 1925, 194, "Modernist", new List<Author> { author5 });
                var book12 = new Book(12012, "To the Lighthouse", "A family visits their summer home on the Isle of Skye", 1927, 209, "Modernist", new List<Author> { author5 });
                var book13 = new Book(13013, "The Waves", "Six characters speak their inner thoughts as they grow from childhood to old age", 1931, 256, "Modernist", new List<Author> { author5 });

                var books = new List<Book> { book1, book2, book3, book4, book5, book6, book7, book8, book9, book10, book11, book12, book13 }; // ima' varwolf

                context.Books.AddRange(books);
                await context.SaveChangesAsync();
            }

            if (!context.Borrowers.Any())
            {
                var borrower1 = new Borrower("Magnus", "Jensen", 8000, "Aarhus", "Midtjylland", "Åboulevarden", "12", "12345678", "magnus.jensen@email.dk");
                var borrower2 = new Borrower("Sofia", "Nielsen", 2100, "København", "Hovedstaden", "Østerbrogade", "45B", "87654321", "sofia.nielsen@email.dk");
                var borrower3 = new Borrower("Lucas", "Andersen", 5000, "Odense", "Syddanmark", "Vestergade", "7", "11223344", "lucas.andersen@email.dk");
                var borrower4 = new Borrower("Emma", "Christensen", 9000, "Aalborg", "Nordjylland", "Boulevarden", "23", "44332211", "emma.christensen@email.dk");

                var borrowers = new List<Borrower> { borrower1, borrower2, borrower3, borrower4 };
                context.Borrowers.AddRange(borrowers);
                await context.SaveChangesAsync();
            }

            if (!context.Loans.Any()) // ok this one is gonna be unhinged. Var levels will be over 9000
            {
                var borrower1 = context.Borrowers.FirstOrDefault(a => a.Name.FirstName == "Magnus" && a.Name.LastName == "Jensen"); // Retrieve the borrower from context to associate with the loan
                var borrower2 = context.Borrowers.FirstOrDefault(a => a.Name.FirstName == "Sofia" && a.Name.LastName == "Nielsen");
                var borrower3 = context.Borrowers.FirstOrDefault(a => a.Name.FirstName == "Lucas" && a.Name.LastName == "Andersen");
                var borrower4 = context.Borrowers.FirstOrDefault(a => a.Name.FirstName == "Emma" && a.Name.LastName == "Christensen");

                var book1 = context.Books.FirstOrDefault(b => b.Title == "The Great Gatsby");
                var book3 = context.Books.FirstOrDefault(b => b.Title == "Pride and Prejudice");
                var book6 = context.Books.FirstOrDefault(b => b.Title == "1984");
                var book8 = context.Books.FirstOrDefault(b => b.Title == "The Old Man and the Sea");
                var book2 = context.Books.FirstOrDefault(b => b.Title == "Tender Is the Night");
                var book7 = context.Books.FirstOrDefault(b => b.Title == "Animal Farm");
                var book11 = context.Books.FirstOrDefault(b => b.Title == "Mrs Dalloway");
                var book5 = context.Books.FirstOrDefault(b => b.Title == "Emma");
                var book9 = context.Books.FirstOrDefault(b => b.Title == "A Farewell to Arms");
                var book12 = context.Books.FirstOrDefault(b => b.Title == "To the Lighthouse");
                var book4 = context.Books.FirstOrDefault(b => b.Title == "Sense and Sensibility");
                var book10 = context.Books.FirstOrDefault(b => b.Title == "For Whom the Bell Tolls");
                var book13 = context.Books.FirstOrDefault(b => b.Title == "The Waves");

                var loan1 = new Loan(borrower1, book1, new DateTime(2026, 4, 15));
                var loan2 = new Loan(borrower1, book3, new DateTime(2026, 5, 3));
                var loan3 = new Loan(borrower2, book6, new DateTime(2026, 7, 18));
                var loan4 = new Loan(borrower2, book8, new DateTime(2026, 12, 7));
                var loan5 = new Loan(borrower3, book2, new DateTime(2026, 9, 22));
                var loan6 = new Loan(borrower3, book7, new DateTime(2026, 10, 10));
                var loan7 = new Loan(borrower4, book11, new DateTime(2026, 12, 28));
                var loan8 = new Loan(borrower4, book5, new DateTime(2026, 5, 14));
                var loan9 = new Loan(borrower1, book9, new DateTime(2026, 6, 1));
                var loan10 = new Loan(borrower2, book12, new DateTime(2026, 6, 19));
                var loan11 = new Loan(borrower3, book4, new DateTime(2026, 7, 8));
                var loan12 = new Loan(borrower4, book10, new DateTime(2026, 7, 25));
                var loan13 = new Loan(borrower1, book13, new DateTime(2026, 8, 12));
                var loan14 = new Loan(borrower2, book2, new DateTime(2026, 9, 3));
                var loan15 = new Loan(borrower3, book6, new DateTime(2026, 10, 17));

                var loans = new List<Loan> { loan1, loan2, loan3, loan4, loan5, loan6, loan7, loan8, loan9, loan10, loan11, loan12, loan13, loan14, loan15 };
                context.Loans.AddRange(loans);
                await context.SaveChangesAsync();
            }
        }
    }
}
