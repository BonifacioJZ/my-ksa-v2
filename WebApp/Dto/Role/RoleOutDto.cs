using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Dto.Role
{
    public class RoleOutDto
    {
        public Guid Id { get; set; }
        
        [Display(Name ="Nombre")]
        public string? Name { get; set; }
    }
}