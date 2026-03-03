using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Data.Configs;

namespace Infrastructure.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public LibraryContext() { }

        public DbSet<Domain.Entities.Book> Books { get; set; }
        public DbSet<Domain.Entities.Author> Authors { get; set; }
        public DbSet<Domain.Entities.Borrower> Borrowers { get; set; }
        public DbSet<Domain.Entities.Loan> Loans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.ConfigureSqLite();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BorrowerConfiguration());
            modelBuilder.ApplyConfiguration(new LoanConfiguration());
        }
    }
}
