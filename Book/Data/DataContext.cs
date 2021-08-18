using Book.Models;
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
    }
}
