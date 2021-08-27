using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Models
{
    public class UserModel:IdentityUser
    {
public int MyBookId{get; set; }
        public ICollection<BookModel> MyBook { get; set; } = new HashSet<BookModel>();
    }
}
