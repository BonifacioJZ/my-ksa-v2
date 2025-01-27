using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Dto.Category
{
     public class CategoryInDto
    {
        [Required]
        [MaxLength(150)]
        public string Name {get;set;} ="name";
        public string? Description {get;set;}
    }
}