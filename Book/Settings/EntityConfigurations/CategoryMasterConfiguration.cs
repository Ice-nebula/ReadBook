using Book.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Settings.EntityConfigurations
{
    public class CategoryMasterConfiguration : IEntityTypeConfiguration<CategoryMasterModel>
    {
        public void Configure(EntityTypeBuilder<CategoryMasterModel> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(250).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
