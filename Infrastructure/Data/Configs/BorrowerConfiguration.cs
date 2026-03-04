using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs
{
    public class BorrowerConfiguration : IEntityTypeConfiguration<Borrower>
    {
        public void Configure(EntityTypeBuilder<Borrower> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Name, name => 
            {
                name.Property(n => n.FirstName).IsRequired().HasMaxLength(50);
                name.Property(n => n.LastName).IsRequired().HasMaxLength(75);
            });

            builder.OwnsOne(x => x.Address, address =>
            {
                address.Property(a => a.ZipCode).IsRequired();
                address.Property(a => a.City).IsRequired().HasMaxLength(50);
                address.Property(a => a.Region).IsRequired().HasMaxLength(50);
                address.Property(a => a.StreetName).IsRequired().HasMaxLength(50);
                address.Property(a => a.StreetNumber).IsRequired().HasMaxLength(10);
            });

            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(30);

            builder.HasMany(x => x.Loans)
                .WithOne(l => l.Borrower)
                .HasForeignKey("BorrowerId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(x => x.CanBorrow);
            builder.Ignore(x => x.HasOverdueLoans);

        }
    }
}
