using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApp.Controllers;

namespace WebApp.Filter
{
    /// <summary>
    /// Filtro para verificar la sesión del usuario.
    /// </summary>
    public class VerifySession : IAsyncActionFilter
    {
        /// <summary>
        /// Método que se ejecuta antes y después de la acción del controlador.
        /// </summary>
        /// <param name="context">Contexto de la acción que se está ejecutando.</param>
        /// <param name="next">Delegado para ejecutar la siguiente acción.</param>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Obtiene el usuario del contexto HTTP.
            var user = context.HttpContext.User;
            
            // Verifica si el usuario no está autenticado.
            if(!user.Identity!.IsAuthenticated)
            {
                // Si el controlador no es AuthenticationController, redirige al login.
                if(context.Controller is AuthenticationController == false)
                {
                    context.HttpContext.Response.Redirect("/Authentication/Login/");
                }
            }
            else
            {
                // Si el usuario está autenticado y el controlador es AuthenticationController, redirige al índice.
                if(context.Controller is AuthenticationController == true)
                {
                    context.HttpContext.Response.Redirect("/Home/Index");
                }
            }
            
            // Ejecuta la siguiente acción en la cadena de filtros.
            await next();
        }
    }
}