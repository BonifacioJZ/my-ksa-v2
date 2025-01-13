using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Seed;

namespace WebApp
{
    /// <summary>
    /// Contexto de la base de datos para la aplicación WebApp.
    /// Hereda de DbContext de Entity Framework Core.
    /// </summary>
    public class Context : IdentityDbContext<User, Role, string>
    {
        /// <summary>
        /// Constructor que recibe opciones de configuración para el contexto.
        /// </summary>
        /// <param name="options">Opciones de configuración para el contexto.</param>
        public Context(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Método llamado al crear el modelo de la base de datos.
        /// Aquí se pueden aplicar configuraciones adicionales al modelo.
        /// </summary>
        /// <param name="builder">El constructor del modelo.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Descomentar las siguientes líneas para aplicar configuraciones específicas
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleUserConfiguration());
        }
        public DbSet<Category> Categories {get;set;}

    }
}