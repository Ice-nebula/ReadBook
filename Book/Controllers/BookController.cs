using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Book.Data;
using Book.Models;
using Book.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Controllers
{
    public class BookController : Controller
    {
        private readonly DataContext _dataContext;
        public IMapper _mapper;
        public ILogger<BookController> _logger;

        public BookController(DataContext dataContext, IMapper mapper, ILogger<BookController> logger)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _logger = logger;
        }
        [Authorize]
        public IActionResult Writer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Writer(WriteBookVm writeBookVm)
        {
            if (ModelState.IsValid == false) return View();
            var map = _mapper.Map<BookModel>(writeBookVm);

            map.Auther = User.Identity.Name;
            map.DateCreated = DateTime.Now;
            await _dataContext.Book.AddAsync(map);
            await _dataContext.SaveChangesAsync();
            return View();
        } //end method.Writer
    }
}
