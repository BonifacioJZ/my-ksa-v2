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
        Task<PermissionDetailDto?> GetDtoById(string id);
    }
}