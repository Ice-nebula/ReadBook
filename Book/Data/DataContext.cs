using Book.Models;
using Book.Settings.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Data
{
    public class DataContext : IdentityDbContext<UserModel>
    {
        // DbSet
        public DbSet<BookModel> Book { get; set; }
        public DbSet<BookCategoryModel> BookCategory { get; set; }
        public DbSet<CategoryMasterModel> CategoryMaster { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new BookChapterConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
