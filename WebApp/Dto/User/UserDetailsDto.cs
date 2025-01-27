using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Dto.User
{
    public class UserDetailsDto
    {
        public Guid Id { get; set; }
        [Display(Name = "Nombre")]
        public string? FirstName { get; set;}
        [Display(Name ="Apellidos")]
        public string? LastName { get; set;}
        [Display(Name = "Nombre de Usuario")]
        public string? UserName { get; set;}
        [Display(Name ="Correo Electronico")]
        public string? Email { get; set;}
        public IList<string>? Role {get; set;}
    }
}