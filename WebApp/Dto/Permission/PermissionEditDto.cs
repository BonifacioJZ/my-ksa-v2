
using System.ComponentModel;


namespace WebApp.Dto.Permission
{
    public class PermissionEditDto
    {
        public string? Id {get; set;}
        public string? Name {get;set;}
        [DisplayName("Descripcion")]
        public string? Description {get;set;}
    }
}