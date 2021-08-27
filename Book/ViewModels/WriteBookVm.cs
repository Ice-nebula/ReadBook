using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book.ViewModels
{
    public class WriteBookVm
    {
        [Required]
        public string BookName { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        public bool Publish { get; set; }
public string MyUserId{get; set; }
        public int[] CategoryId { get; set; }
    }
}
