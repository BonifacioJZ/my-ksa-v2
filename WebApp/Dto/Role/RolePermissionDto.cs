using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Dto.Permission;

namespace WebApp.Dto.Role
{
    public class RolePermissionDto
    {
        public string? Id {get;set;}
        public string? Name {get;set;}
        public string? Description {get;set;}
        public ICollection<PermissionOutDto>? Permissions {get;set;} 
    }
}