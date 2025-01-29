using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApp.Data;
using WebApp.Models;
using WebApp.Service.Interface;

namespace WebApp.Controllers
{
    
    public class PermissionController : Controller
    {
        private readonly ILogger<PermissionController> _logger;
        private readonly IPermissionService _service;
        public PermissionController(ILogger<PermissionController> logger,IPermissionService service)
        {
            _logger = logger;
            _service = service;
        }
        
        [Authorize(Policy ="SuperUser")]
        public async Task<IActionResult> Index(int? numPage)
        {
            var permissions = _service.All();
            return View(await Pagination<Permission>.PaginationCreate(permissions.AsNoTracking(),numPage??1,5));
        }

        public async Task<IActionResult> Show(string id){
            var permission = await _service.GetDtoById(id);
            
            if(permission==null) return NotFound();

            return View(permission);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}