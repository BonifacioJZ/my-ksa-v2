using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly Context _context;
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// Constructor de la clase UserService.
        /// </summary>
        /// <param name="signInManager">Instancia de SignInManager para manejar el inicio y cierre de sesión.</param>
        /// <param name="context">Contexto de la base de datos.</param>
        /// <param name="userManager">Instancia de UserManager para manejar usuarios.</param>
        public UserService(SignInManager<User> signInManager, Context context, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _context = context;
            _userManager = userManager;
        }

        /// <summary>
        /// Verifica si existe un usuario con el correo electrónico especificado.
        /// </summary>
        /// <param name="email">Correo electrónico a verificar.</param>
        /// <returns>True si existe un usuario con el correo electrónico especificado, de lo contrario false.</returns>
        public async Task<bool> ExistEmail(string email)
        {
            return await _context.Users.Where(u => u.Email == email).AnyAsync();
        }

        /// <summary>
        /// Verifica si existe un usuario con el nombre de usuario especificado.
        /// </summary>
        /// <param name="userName">Nombre de usuario a verificar.</param>
        /// <returns>True si existe un usuario con el nombre de usuario especificado, de lo contrario false.</returns>
        public async Task<bool> ExistUserName(string userName)
        {
            return await _context.Users.Where(u => u.UserName == userName).AnyAsync();
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

        /// <summary>
        /// Registra un nuevo usuario en el sistema.
        /// </summary>
        /// <param name="dto">DTO con la información del usuario a registrar.</param>
        /// <returns>Resultado de la operación de registro.</returns>
        public async Task<IdentityResult> Register(RegisterDto dto)
        {
            User user = new User
            {
                UserName = dto.Username,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastNAme = dto.LastName
            };

            var result = await _userManager.CreateAsync(user, dto.Password!);
            if (!result.Succeeded) return result;

            result = await _userManager.AddToRoleAsync(user, dto.Role!);
            return result;
        }
    }
}