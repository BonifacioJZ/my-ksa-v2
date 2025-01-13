using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Models
{
    public class Role:IdentityRole
    {
        [Column(TypeName ="description")]
        public string? Description { get; set; }
    }
}