using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Dto.Permission
{
    public class PermissionOutDto
    {
        public string? Id {get;set;}
        public string? Name {get;set;}
        [DisplayName("Descripcion")]
        public string? Description {get;set;}
    }
}