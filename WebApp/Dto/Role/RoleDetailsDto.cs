using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Dto.Role
{
    public class RoleDetailsDto
    {
        public Guid Id { get; set; }
        [Display(Name ="Nombre")]
        public string? Name { get; set; }
        [Display(Name ="Descripcion")]
        public string? Description { get; set; }
    }
}