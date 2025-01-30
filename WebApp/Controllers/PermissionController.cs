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
using WebApp.Dto.Permission;
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

        public async Task<IActionResult> Edit(string id){
            var permission = await _service.EditDto(id);
            if(permission == null) return NotFound();
            return View(permission);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string id,[Bind("Id","Name","Description")]PermissionEditDto dto){
            if(id != dto.Id) return NotFound();
            if(!ModelState.IsValid){
                TempData["Error_data"] ="El Intento de Actualizacion no Valido";
                return View("Edit",dto);
            }
            try{
                await _service.Update(dto);
            }catch(DbUpdateConcurrencyException){
                if(!_service.Exists(id)){
                    return NotFound();
                }else{
                    TempData["Error_data"] ="El Intento de Actualizacion no Valido";
                    throw ;
                }
            }
            TempData["Success_data"]="El permiso se a actualizado correctamente";
            return RedirectToAction(nameof(Index));
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}