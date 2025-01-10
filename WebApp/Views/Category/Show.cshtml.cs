using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApp.Views.Category
{
    public class Show : PageModel
    {
        private readonly ILogger<Show> _logger;

        public Show(ILogger<Show> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}