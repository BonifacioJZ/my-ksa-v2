using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApp.Dto.Category;
using WebApp.Models;

namespace WebApp.Mapper
{
    public class ProfileCategory:Profile
    {
        public ProfileCategory()
        {
            CreateMap<Category, CategoryInDto>().ReverseMap();
        }
    }
}