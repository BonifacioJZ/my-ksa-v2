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
            var permissions = _context.Permission.Select((e)=>e);
            return permissions;
        }

        public async Task<PermissionDetailDto?> GetDtoById(string id)
        {
            var permission = _mapper.Map<PermissionDetailDto>(
                await _context.Permission.FindAsync(id)
            );
            return permission;
        }
    }
}