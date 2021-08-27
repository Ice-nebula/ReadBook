using Book.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Settings.EntityConfigurations
{
    public class BookChapterConfiguration : IEntityTypeConfiguration<BookChapterModel>
    {
        public void Configure(EntityTypeBuilder<BookChapterModel> builder)
        {
            builder.Property(x => x.Content)
                .IsRequired();
            builder.Property(x => x.Title)
                .HasMaxLength(512).IsRequired();
            builder.HasIndex(x => new { x.Title, x.Publish }).IsUnique();
        }
    }
}
