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

        public IQueryable<Role> All()
        {
            var roles = _roleManager.Roles.Where(r => r.Name != "Root");
            return roles; 
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

        /// <summary>
        /// Crea un nuevo rol.
        /// </summary>
        /// <param name="dtoRole">DTO con los datos del rol a crear.</param>
        /// <returns>Resultado de la creación del rol.</returns>
        public async Task<IdentityResult?> Create(RoleEditDto dtoRole)
        {
            var role = new Role()
            {
                Name = dtoRole.Name,
                Description = dtoRole.Description,
                NormalizedName = dtoRole.Name!.Normalize()
            };
            return await _roleManager.CreateAsync(role);
        }

        /// <summary>
        /// Elimina un rol por su ID.
        /// </summary>
        /// <param name="id">ID del rol a eliminar.</param>
        public async void Destroy(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role != null)
            {
                await _roleManager.DeleteAsync(role);
            }
        }

        /// <summary>
        /// Edita un rol existente.
        /// </summary>
        /// <param name="id">ID del rol a editar.</param>
        /// <returns>DTO de edición del rol, o null si no se encuentra.</returns>
        public async Task<RoleEditDto?> Edit(Guid id)
        {
            var role = _mapper.Map<RoleEditDto>(await _roleManager.FindByIdAsync(id.ToString()));
            return role;
        }

        /// <summary>
        /// Verifica si un rol existe por su ID.
        /// </summary>
        /// <param name="id">ID del rol a verificar.</param>
        /// <returns>True si el rol existe, false en caso contrario.</returns>
        public bool Exist(Guid id)
        {
            return (_roleManager.Roles?.Any(r => r.Id == id.ToString())).GetValueOrDefault();
        }

        /// <summary>
        /// Encuentra un rol por su ID.
        /// </summary>
        /// <param name="id">ID del rol a encontrar.</param>
        /// <returns>DTO con los detalles del rol.</returns>
        public async Task<RoleDetailsDto> FindById(Guid id)
        {
            var role = _mapper.Map<RoleDetailsDto>(await 
            _roleManager.FindByIdAsync(id.ToString()));
            return role;
        }

        /// <summary>
        /// Actualiza un rol existente.
        /// </summary>
        /// <param name="role">DTO de edición con los datos actualizados del rol.</param>
        /// <returns>Resultado de la actualización del rol.</returns>
        public async Task<IdentityResult?> Update(RoleEditDto role)
        {
            var updateRole = await _roleManager.Roles.FirstOrDefaultAsync(r => r.Id == role.Id.ToString());
            
            updateRole!.Name = role.Name??updateRole.Name;
            updateRole.Description = role.Description??updateRole.Description;
            updateRole.NormalizedName = role.Name?.Normalize()??updateRole.Name!.Normalize();
            
            var result = await _roleManager.UpdateAsync(updateRole);
            return result;
        }
    }
}