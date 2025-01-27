using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApp.Views.Category
{
    public class New : PageModel
    {
        private readonly ILogger<New> _logger;

        public New(ILogger<New> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}