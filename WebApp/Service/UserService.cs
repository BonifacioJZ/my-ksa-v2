using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebApp.Dto.Authentication;
using WebApp.Models;
using WebApp.Service.Interface;

namespace WebApp.Service
{
    /// <summary>
    /// Servicio para manejar la autenticación de usuarios.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly SignInManager<User> _signInManager;

        /// <summary>
        /// Constructor de la clase UserService.
        /// </summary>
        /// <param name="signInManager">Instancia de SignInManager para manejar el inicio y cierre de sesión.</param>
        public UserService(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        /// <summary>
        /// Método para iniciar sesión.
        /// </summary>
        /// <param name="dto">DTO con los datos de inicio de sesión.</param>
        /// <returns>Resultado del intento de inicio de sesión.</returns>
        public async Task<SignInResult> LogIn(LoginDto dto)
        {
            // Intenta iniciar sesión con los datos proporcionados.
            var result = await _signInManager.PasswordSignInAsync(dto.Username!, dto.Password!, dto.RememberMe, false);
            return result;
        }

        /// <summary>
        /// Método para cerrar sesión.
        /// </summary>
        public async void LogOut()
        {
            // Cierra la sesión del usuario.
            await _signInManager.SignOutAsync();
        }
    }
}