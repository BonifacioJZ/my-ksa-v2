using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApp.Dto.Role;
using WebApp.Models;

namespace WebApp.Mapper
{
    public class ProfileRole:Profile
    {
        public ProfileRole()
        {
            CreateMap<Role,RoleOutDto>().ReverseMap();
            CreateMap<Role,RoleDetailsDto>().ReverseMap();
            CreateMap<Role,RoleEditDto>().ReverseMap();
            CreateMap<Role,RoleIntDto>().ReverseMap();
        }
    }
}