using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApp.Views.Role
{
    public class AssignPermission : PageModel
    {
        private readonly ILogger<AssignPermission> _logger;

        public AssignPermission(ILogger<AssignPermission> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}