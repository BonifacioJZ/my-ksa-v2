using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApp.Data;
using WebApp.Models;
using WebApp.Service.Interface;

namespace WebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<Category> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<Category> logger,ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        public async Task<ActionResult> Index(string search, string currentOrder,int? numPage,string currentFilter)
        {
            if(search !=null)
                numPage = 1;
            else
                search = currentFilter;
            
            ViewData["OrdenActual"] = currentOrder;
            ViewData["FiltroActual"] = search;
            var categories = _categoryService.All(search,currentOrder);

            return View(await Pagination<Category>.PaginationCreate(categories.AsNoTracking(),numPage??1,5));
        }
        public IActionResult New(){
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

    }
}