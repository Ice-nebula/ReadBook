using AutoMapper;
using Book.Data;
using Book.Models;
using Book.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger, DataContext dataContext, IMapper mapper)
        {
            _logger = logger;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var query = await _dataContext.Book.Where(x => x.Publish == true)
                .Select(x => new GetAllBooks
                {
                    Auther = x.Auther,
                    BookName = x.BookName,
                    DateCreated = x.DateCreated
                })
                .OrderBy(x => x.DateCreated).Take(20).ToListAsync();
            return View(query);
        }
       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
