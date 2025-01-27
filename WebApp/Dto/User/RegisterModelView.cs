using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Dto.Role;

namespace WebApp.Dto.User
{
    public class RegisterModelView
    {
        [Required]
        [StringLength(maximumLength:150)]
        [Display(Name ="Nombre")]
        public string? FirstName {get; set;}
        [Required]
        [StringLength(maximumLength:150)]
        [Display(Name ="Apellidos")]
        public string? LastName {get; set;}
        [Required]
        [Display(Name ="Nombre de Ususario")]
        public string? Username {get; set;}
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Correo Electronico")]
        public string? Email {get; set;}
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Contraseña")]
        [MaxLength(32)]
        [MinLength(8)]
        public string? Password {get; set;}
        [Required]
        [Compare(nameof(Password))]
        [Display(Name ="Confirmar Contraseña")]
        public string? ConfirmPassword {get; set; }

        [Required]
        public ICollection<RoleOutDto>? Role {get;set;} 
    }
}