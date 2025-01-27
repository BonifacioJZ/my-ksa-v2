using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApp.Views.Shared
{
    public class _LinkPartial : PageModel
    {
        private readonly ILogger<_LinkPartial> _logger;

        public _LinkPartial(ILogger<_LinkPartial> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}