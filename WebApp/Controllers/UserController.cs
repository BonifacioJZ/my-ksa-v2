using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApp.Data;
using WebApp.Dto.Authentication;
using WebApp.Dto.User;
using WebApp.Models;
using WebApp.Service.Interface;

namespace WebApp.Controllers
{
    
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UserController(ILogger<UserController> logger,IUserService userService,IRoleService roleService)
        {
            _logger = logger;
            _userService = userService;
            _roleService = roleService;
        }

        public async Task<IActionResult> Index(int? numPage){
            var users = _userService.All();

            return View(await Pagination<User>.PaginationCreate(users.AsNoTracking(),numPage??1,10));
        }
        public async Task<IActionResult> Register()
        {
            RegisterModelView register = new RegisterModelView();
            register.Role = await _roleService.AllDto();
            return View(register);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("FirstName","LastName","Username","Email","Password","ConfirmPassword","Role")]RegisterDto model){
            if(ModelState.IsValid){
                if(model.Role=="Selecione un rol"){
                    ModelState.AddModelError(string.Empty, "Seleccione un rol");
                    return View(await ConverterToRegisterModelView(model));

                }
                //TODO(Validar si existe el rol)
                if(await _userService.ExistUserName(model.Username!)){
                    ModelState.AddModelError("Username","El Nombre de usuario ya existe");
                    return View(await ConverterToRegisterModelView(model));
                }
                
                if(await _userService.ExistEmail(model.Email!)){
                    ModelState.AddModelError("Email","El Correo electronico ya existe");
                    return View(await ConverterToRegisterModelView(model));
                }
                
                var result = await _userService.Register(model);
                
                if(result.Succeeded){
                    return RedirectToAction("Index","Home");
                }

                foreach(var error in result.Errors){
                    ModelState.AddModelError(string.Empty,error.Description);
                }
            }
            return View(await ConverterToRegisterModelView(model));
        }

        public async Task<IActionResult> Show(Guid id){
            var user  = await _userService.GetById(id);
            if(user == null) return NotFound();
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
        private async Task<RegisterModelView> ConverterToRegisterModelView(RegisterDto user){
            RegisterModelView model = new RegisterModelView(){
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username,
                Role = await _roleService.AllDto(),
            };
            return model;
        }
    }
}