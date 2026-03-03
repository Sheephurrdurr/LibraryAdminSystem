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

            builder.HasMany(x => x.Authors)
                .WithMany(x => x.Books)
                .UsingEntity(j => j.ToTable("BookAuthors"));


        }
    }
}
