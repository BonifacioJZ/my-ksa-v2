using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Models
{
    public class User : IdentityUser
    {
        [MaxLength(150)]
        [Column(TypeName ="first_name")]
        public string? FirstName {get;set;}
        [MaxLength(150)]
        [Column(TypeName ="last_name")]
        public string? LastNAme {get;set;}   
    }
}