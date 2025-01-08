using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Category
    {
        [Key]
        [Column(TypeName ="id")]
        public Guid Id {get;set;}
        [Required]
        [Column(TypeName ="name")]
        [MaxLength(150)]
        public string Name {get;set;} ="";
        [Column(TypeName ="description")]
        public string? Description {get;set;}

    }
}