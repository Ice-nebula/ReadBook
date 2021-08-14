using AutoMapper;
using Book.Data;
using Book.Models;
using Book.ViewModels.Admin;
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
            var query = await _dataContext.BookCategory.ToListAsync();
            var map = _mapper.Map<IEnumerable<CategoryVm>>(query);
            var catvm = new CategoryManageVm();
            catvm.GetCategorys = map;
            return View(catvm);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(string CategoryName)
        {
            if (string.IsNullOrEmpty(CategoryName) == true)
            {
                return BadRequest(new { message = "CategoryName can not be empty" });
                } //end if
            if (_dataContext.BookCategory.Any(x => x.CategoryName == CategoryName) == true)
            {
                return BadRequest(new { message = "หมวดหมู่นี้มีอยู่ในระบบแล้ว" });
            }
            var bcn = new BookCategoryModel()
            {
                CategoryName = CategoryName
            };
            await _dataContext.BookCategory.AddAsync(bcn);
            await _dataContext.SaveChangesAsync();
            return Ok(new { Message = "เพิ่มหมวดหมู่ " + CategoryName + "สำเร็จ"});
            }
    }
}
