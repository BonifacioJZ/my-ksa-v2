using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Dto.Role
{
    public class RoleEditDto
    {
        
        [Required]
        public Guid Id {get;set;}
        [Required]
        [MaxLength(150)]
        [Display(Name ="Nombre")]
        public string? Name {get;set;}
        [Display(Name ="Descripcion")]
        public string? Description {get;set;}
    }
}