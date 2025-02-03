using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApp.Dto.Permission;
using WebApp.Dto.Role;
using WebApp.Models;

namespace WebApp.Mapper
{
    public class ProfileRole:Profile
    {
        public ProfileRole()
        {
            CreateMap<Role,RoleOutDto>().ReverseMap();
            
            CreateMap<Role,RoleDetailsDto>()
            .ForMember(r=>r.PermissionsDto,y=>y.MapFrom(
                z=>z.Permissions
            )).ReverseMap();
            CreateMap<Role,RoleEditDto>().ReverseMap();
            CreateMap<Role,RoleIntDto>().ReverseMap();
            CreateMap<Role,RolePermissionDto>().ReverseMap();
        }
    }
}