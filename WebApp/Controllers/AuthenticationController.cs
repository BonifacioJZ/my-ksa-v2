using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Dto.Authentication;
using WebApp.Models;
using WebApp.Service.Interface;

namespace WebApp.Controllers
{
    /// <summary>
    /// Controlador para manejar la autenticación de usuarios.
    /// </summary>
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly UserManager<User> userManager;
        /// <summary>
        /// Constructor de la clase AuthenticationController.
        /// </summary>
        /// <param name="logger">Instancia de ILogger para el controlador.</param>
        /// <param name="userService">Servicio de usuario para manejar la autenticación.</param>
        public AuthenticationController(ILogger<AuthenticationController> logger, IUserService userService,UserManager<User> userManager)
        {
            _logger = logger;
            _userService = userService;
            this.userManager = userManager;
        }

        /// <summary>
        /// Acción para mostrar la vista de inicio de sesión.
        /// </summary>
        /// <returns>Retorna la vista de inicio de sesión.</returns>
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        /// <summary>
        /// Acción para manejar el inicio de sesión.
        /// </summary>
        /// <param name="dto">DTO con los datos de inicio de sesión.</param>
        /// <returns>Redirige al índice si el inicio de sesión es exitoso, de lo contrario, retorna la vista de inicio de sesión con errores.</returns>
        public async Task<IActionResult> Login([Bind("Username,Password,RememberMe")] LoginDto dto)
        {
            if (ModelState.IsValid)
            {
                // Intenta iniciar sesión con los datos proporcionados.
                var result = await _userService.LogIn(dto);
                if (result.Succeeded)
                {
                    // Redirige al índice si el inicio de sesión es exitoso.
                    var user = HttpContext.User;
                    return RedirectToAction("Index", "Home");
                }
                // Agrega un error al estado del modelo si el inicio de sesión falla.
                ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos");
            }
            // Retorna la vista de inicio de sesión con los datos y errores.
            return View(dto);
        }

        /// <summary>
        /// Acción para manejar el cierre de sesión.
        /// </summary>
        /// <returns>Redirige a la vista de inicio de sesión.</returns>
        public IActionResult Logout()
        {
            // Cierra la sesión del usuario.
            _userService.LogOut();
            // Redirige a la vista de inicio de sesión.
            return RedirectToAction("Login", "Authentication");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        /// <summary>
        /// Acción para manejar los errores.
        /// </summary>
        /// <returns>Retorna la vista de error.</returns>
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}