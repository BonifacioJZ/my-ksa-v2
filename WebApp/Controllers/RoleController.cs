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
using WebApp.Dto.Role;
using WebApp.Models;
using WebApp.Service.Interface;

namespace WebApp.Controllers
{
    
    public class RoleController : Controller
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IRoleService _roleService;
        public RoleController(ILogger<RoleController> logger, IRoleService roleService)
        {
            _logger = logger;
            _roleService = roleService;
        }
        
        [Authorize(Policy ="SuperUser")]
        public async Task<IActionResult> Index(int? numPag)
        {
            var roles = _roleService.All(); 
            return View(await Pagination<Role>.PaginationCreate(roles, numPag ?? 1, 10));
        }
        [Authorize(Policy ="SuperUser")]
        public IActionResult Create(){
            return View();
        }

        [Authorize(Policy ="SuperUser")]
        public async Task<IActionResult> Show(Guid id){
            var role = await _roleService.FindById(id);
            if(role ==null){
                return NotFound();
            }
            return View(role);
        }
        [Authorize(Policy ="SuperUser")]
        public async Task<IActionResult> Edit(Guid id){
            var role = await _roleService.Edit(id);
            if(role == null){
                return NotFound();
            }
            return View(role);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy ="SuperUser")]
        public async Task<IActionResult> Store([Bind("Name","Description")]RoleEditDto role){
            if(ModelState.IsValid){
                var success = await _roleService.Create(role);
                if(success!.Succeeded){
                    TempData["Success_data"]="El Rol se a creado correctamente";
                    return RedirectToAction(nameof(Index));
                }
                TempData["Error_data"]="Error al crear el Rol";
                return View("Create",role);
            }
            return View(role);
        }

        //TODO:Optimizar update
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy ="SuperUser")]
        public async Task<IActionResult> Update(Guid id, [Bind("Id","Name","Description")]RoleEditDto role){
            if(id != role.Id) return NotFound();
            
            if(ModelState.IsValid){
                try{
                    await _roleService.Update(role);
                }catch(DbUpdateConcurrencyException){
                    if(!_roleService.Exist(id)){
                        return NotFound();
                    }else{
                        TempData["Error_data"] ="El Intento de Actualizacion no Valido";
                        throw ;
                    }
                }
                TempData["Success_data"]="El Rol se a actualizado correctamente";
                return RedirectToAction(nameof(Index));

            }
            return View("edit",role);
        }

        [Authorize(Policy ="SuperUser")]
        public async Task<IActionResult> Delete(Guid id){
            var role = await _roleService.FindById(id);
            if(role == null){
                return NotFound();
            }
            return View(role);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy ="SuperUser")]
        public IActionResult Destroy(Guid id){
            _roleService.Destroy(id);
            TempData["Success_data"]="El Rol se a eliminado correctamente";
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}