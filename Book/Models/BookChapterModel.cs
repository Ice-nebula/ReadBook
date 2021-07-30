using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Models
{
    [Index(nameof(Id),nameof(Publish), IsUnique =  true)]
    public class BookChapterModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public bool Publish { get; set; }
        public DateTime DateCreated { get; set; }
        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }
        public BookModel Book{ get; set; }
        
    }
}
