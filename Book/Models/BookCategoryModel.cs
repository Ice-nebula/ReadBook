using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Models
{
    public class BookCategoryModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool Show { get; set; }
    }
}
