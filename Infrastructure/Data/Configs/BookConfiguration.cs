using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ISBN)
                .IsRequired();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.Property(x => x.PagesAmount)
                .IsRequired();

            builder.Property(x => x.Genre)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(x => x.Loans)
                .WithOne(x => x.Book)
                .HasForeignKey("BookId")
                .OnDelete(DeleteBehavior.Cascade); // one to many relation, so we need foreign key "BookId" in "Loan" table

            builder.HasMany(x => x.Author)
                .WithMany(x => x.Books)
                .UsingEntity(j => j.ToTable("BookAuthors")); // many to many relation, so we need  junction table "BookAuthors"

            builder.Ignore(x => x.IsAvailable);


        }
    }
}
