using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Dto.Role;

namespace WebApp.Service.Interface
{
    public interface IRoleService
    {
        Task<ICollection<RoleOutDto>> AllDto();
    }
}