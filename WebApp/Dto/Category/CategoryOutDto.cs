using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Dto.Category
{
    public class CategoryOutDto
    {
        public Guid Id {get;set;}
        public string Name {get;set;} ="name";
        public string? Description {get;set;} 
    }
}