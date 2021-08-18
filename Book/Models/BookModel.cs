using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Models
{
    [Index(nameof(BookName), nameof(BookId), nameof(Publish),nameof(DateCreated), IsUnique = true)]
    public class BookModel
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string Auther { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        public bool Publish { get; set; }
        public DateTime DateCreated { get; set; }
    public ICollection<BookChapterModel> bookChapters { get; set; }
        public ICollection<BookCategoryModel> BookCategorys { get; set; } = new HashSet<BookCategoryModel>();
    }
}
