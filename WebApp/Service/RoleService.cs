using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Dto.Role;
using WebApp.Models;

namespace WebApp.Service.Interface
{
    /// <summary>
    /// Servicio para la gestión de roles en la aplicación.
    /// Implementa la interfaz IRoleService.
    /// </summary>
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor que inicializa el servicio con RoleManager e IMapper.
        /// </summary>
        /// <param name="roleManager">Administrador de roles de Identity.</param>
        /// <param name="mapper">Instancia de AutoMapper para mapear entidades.</param>
        public RoleService(RoleManager<Role> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todos los roles en formato DTO, excluyendo el rol "Root".
        /// </summary>
        /// <returns>Una colección de roles en formato RoleOutDto.</returns>
        public async Task<ICollection<RoleOutDto>> AllDto()
        {
            var roles = _mapper.Map<ICollection<RoleOutDto>>(await _roleManager.Roles
                .Where(r => r.Name != "Root").ToListAsync());
            return roles;
        }
    }
}