using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Dto.Authentication
{
    public class LoginDto
    {
        [Required]
        [Display(Name = "Nombre de Usuario")]
        public string? Username {get;set;}
        [Required]
        [Display(Name ="Contraseña")]
        [DataType(DataType.Password)]
        public string? Password {get;set;}
        [Display(Name = "Recuerdame")]
        public bool RememberMe {get;set;}
    }
}