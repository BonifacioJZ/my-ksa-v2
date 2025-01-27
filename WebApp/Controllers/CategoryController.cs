using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApp.Data;
using WebApp.Dto.Category;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Store([Bind("Name","Description")]CategoryInDto category){
            if(!ModelState.IsValid){
                TempData["Error_data"]="Los datos de la categoria son incorrectos";
                return View("New",category);
            }
            
            var categoryOutDto = await _categoryService.Create(category);
            if(categoryOutDto == null){
                TempData["Error_data"]="Error al crear la categoria";
                return View("New",category);
            }

            TempData["Success_data"]="La categoria se ha creado correctamente";
            return RedirectToAction(nameof(Index));
        }
        public async Task<ActionResult> Show(Guid id){
            var category = await _categoryService.FindById(id);
            
            if(category == null) return NotFound();
            return View(category);
        }
        public async Task<ActionResult> Edit(Guid id){
            var category = await _categoryService.Edit(id);
            
            if(category == null) return NotFound();
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(Guid id,[Bind("Id","Name","Description")]CategoryEditDto category){
            if(id != category.Id) return NotFound();
            if(!ModelState.IsValid) {
                
                TempData["Error_data"] ="El Intento de Actualizacion no Valido";
                return View("Edit",category);
                
                }
                try{
                    await _categoryService.Update(category);
                }catch(DbUpdateConcurrencyException){
                    if(!_categoryService.Exists(id)){
                        return NotFound();
                    }else{
                        TempData["Error_data"] ="El Intento de Actualizacion no Valido";
                        throw ;
                    }
                }
                
                TempData["Success_data"]="La categoria se a actualizado correctamente";
                return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(Guid id){
            
            var category = await _categoryService.FindById(id);
            
            if(category == null) return NotFound();
            
        return View(category);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Destroy(Guid id){
            _categoryService.Destroy(id);
            TempData["Success_data"]="La categoria se ha eliminado correctamente";
            return RedirectToAction(nameof(Index));
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

    }
}