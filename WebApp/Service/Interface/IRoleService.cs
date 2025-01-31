using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebApp.Dto.Role;
using WebApp.Models;

namespace WebApp.Service.Interface
{
    public interface IRoleService
    {
        Task<ICollection<RoleOutDto>> AllDto();
        IQueryable<Role> All();
        Task<IdentityResult?> Create(RoleEditDto role);    
        Task<RoleDetailsDto> FindById(Guid id);
        Task<RoleEditDto?> Edit(Guid id);
        Task<IdentityResult?> Update(RoleEditDto role);
        Task<Role?> FoundAdvanceByName(string name);
        bool Exist(Guid id);
        void Destroy(Guid id);
    }
}