using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApp.Dto.User;
using WebApp.Models;

namespace WebApp.Mapper
{
    public class ProfileUser:Profile
    {
        public ProfileUser()
        {
            CreateMap<User,UserDetailsDto>().ReverseMap();
        }
    }
}