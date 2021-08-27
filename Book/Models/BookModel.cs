using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Models
{
    public class BookModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
public int AutherId{get; set; }
        public UserModel Auther { get; set; }
        public string ShortDescription { get; set; }
        public bool Publish { get; set; }
        public DateTime DateCreated { get; set; }
    public ICollection<BookChapterModel> bookChapters { get; set; }
        public ICollection<BookCategoryModel> BookCategorys { get; set; } = new HashSet<BookCategoryModel>();
    }
}
