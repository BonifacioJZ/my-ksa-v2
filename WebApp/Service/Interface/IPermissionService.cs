using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Dto.Permission;
using WebApp.Models;

namespace WebApp.Service.Interface
{
    public interface IPermissionService
    {
        IQueryable<Permission> All();
        Task<ICollection<PermissionOutDto>> GetAllDto();
        Task<PermissionDetailDto?> GetDtoById(string id);
        Task<PermissionEditDto?> EditDto(string id);
        Task<PermissionEditDto?> Update(PermissionEditDto dto);
        bool Exists(string id);

    }
}