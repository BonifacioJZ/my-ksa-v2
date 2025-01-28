using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Models
{
    public class Permission
    {
        [Column(TypeName ="id")]
        public string? Id {get;set;}
        [Column(TypeName ="name")]
        [MaxLength(150)]
        public string? Name {get;set;}
        [Column(TypeName ="description ")]
        public string? Description {get;set;}
        [Column(TypeName ="normalize_name")]
        public string? NormalizeName {get;set;}
        [JsonIgnore]
        public virtual ICollection<Role>? Roles {get;set;}
    }
}