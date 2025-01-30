using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApp.Dto.Permission;
using WebApp.Models;

namespace WebApp.Mapper
{
    public class ProfilePermission : Profile
    {
        public ProfilePermission()
        {
            CreateMap<Permission,PermissionDetailDto>().ReverseMap();
            CreateMap<PermissionEditDto,Permission>().ReverseMap();
        }
    }
}