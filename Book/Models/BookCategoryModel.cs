using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Models
{
    public class BookCategoryModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        [ForeignKey(nameof(Book))]
        public int BookId{get; set; }
    public BookModel Book { get; set; }
}
}
