using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApp.Dto.Permission;
using WebApp.Models;
using WebApp.Service.Interface;

namespace WebApp.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public PermissionService(Context context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }
        public IQueryable<Permission> All()
        {
            var permissions = _context.Permission.Where(p=>p.Name !="SuperUser").Select((e)=>e);
            return permissions;
        }

        public async Task<PermissionEditDto?> EditDto(string id)
        {
            var permission = _mapper.Map<PermissionEditDto>(
                await Found(id)
            );
            return permission;
        }

        public bool Exists(string id)
        {
            return (_context.Permission?.Any(r => r.Id == id)).GetValueOrDefault();
        }

        public async Task<PermissionDetailDto?> GetDtoById(string id)
        {
            var permission = _mapper.Map<PermissionDetailDto>(
                await Found(id)
            );
            return permission;
        }

        public async Task<PermissionEditDto?> Update(PermissionEditDto dto)
        {
            var permission = _mapper.Map<Permission>(dto);
            _context.Permission.Update(permission);
            var result = await _context.SaveChangesAsync();
            if (result==0) return null;
            return dto;
        }
        
        private async Task<Permission?> Found(string id){
            return await _context.Permission.FindAsync(id);
        }
    }
}