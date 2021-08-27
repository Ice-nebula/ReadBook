using Book.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Settings.EntityConfigurations
{
    public class BookConfiguration : IEntityTypeConfiguration<BookModel>
    {
        public void Configure(EntityTypeBuilder<BookModel> builder)
        {
            builder.Property(x => x.BookName).IsRequired();
            builder.Property(x => x.BookName).IsRequired();
            builder.HasKey(x => x.BookId);
            builder.HasIndex(x => new { x.Publish, x.BookName }).IsUnique();
            builder.HasMany(x => x.bookChapters)
                .WithOne(x => x.Book);
            builder.HasMany(x => x.BookCategorys)
                .WithOne(x => x.Book);
        }   
    }
}
