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

        
    }
}
