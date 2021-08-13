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
using Microsoft.AspNetCore.Authentication.JwtBearer;

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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Writer(WriteBookVm writeBookVm)
        {
            try
            {
                if (ModelState.IsValid == false) return BadRequest();
                if (_dataContext.Book.Any(x => x.BookName == writeBookVm.BookName))
                {
                    return BadRequest(new { Message = "นิยายเล่มนี้มีอยู่ในระบบแล้ว โปรดใช้ชื่ออื่นนะคะ" });
                } //end if
                var map = _mapper.Map<BookModel>(writeBookVm);

                map.Auther = User.Identity.Name;
                map.DateCreated = DateTime.Now;
                await _dataContext.Book.AddAsync(map);
                await _dataContext.SaveChangesAsync();
                return Ok(new { ResponseMessage = "ok" });
            }
            catch (Exception e)
            {
                return BadRequest(new { Message = e.Message });
            } //end catch
        } //end method.Writer
    }
}
