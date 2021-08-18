using AutoMapper;
using Book.Data;
using Book.Models;
using Book.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Controllers
{
    public class CategoryAdminController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public CategoryAdminController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ListCategory()
        {
            var query = await _dataContext.CategoryMaster.AsNoTracking().ToListAsync();
            var map = _mapper.Map<IEnumerable<GetCategoryMasterVm>>(query);
            return View(map);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryMasterVm categoryMasterVm)
        {
            if (ModelState.IsValid == false) return BadRequest();
            if (_dataContext.CategoryMaster.Any(x => x.Name == categoryMasterVm.Name) == true)
            {
                return BadRequest(new { message = "หมวดหมู่นี้มีอยู่ในระบบแล้ว" });
            } //end if
            CategoryMasterModel map = _mapper.Map<CategoryMasterModel>(categoryMasterVm);
            await _dataContext.CategoryMaster.AddAsync(map);
            await _dataContext.SaveChangesAsync();
            return Ok(new { Message = "เพิ่มหมวดหมู่ " + "สำเร็จ"});
            } //end method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategory(int[] ids)
        {
            if (ids.Length > 0)
            {
                var deleteList = new List<CategoryMasterModel>();
                foreach (var item in ids)
                {
                    var query = await _dataContext.CategoryMaster.SingleOrDefaultAsync(x => x.Id == item);
                    deleteList.Add(query);
                } //end for each
                _dataContext.CategoryMaster.RemoveRange(deleteList);
                await _dataContext.SaveChangesAsync();
            } //end if
            return RedirectToAction(nameof(ListCategory));
        } //end method.Delete Category
    } //end class
}
