using AutoMapper;
using Book.Models;
using Book.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Settings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserModel, LoginVm>().ReverseMap();
            CreateMap<UserModel, RegisterVm>().ReverseMap();
        }
    }
}
