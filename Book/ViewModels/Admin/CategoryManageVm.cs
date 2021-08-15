using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.ViewModels.Admin
{
    public class CategoryManageVm
    {
        public IEnumerable<CategoryVm> GetCategorys { get; set; }
        public int[] CatId { get; set; }
    }
}
