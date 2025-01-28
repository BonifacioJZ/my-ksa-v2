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
            builder.Entity<Permission>()
            .HasMany(p=>p.Roles)
            .WithMany(p=>p.Permissions)
            .UsingEntity<RolePermission>(
                p=>p.HasData(new{
                    PermissionId = "e0cfe636-34ac-4ec3-9ebb-6b93d34d2068",
                    RoleId="87e55637-05ef-45e1-8eb9-d881cdefa88b"
                })
            );
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleUserConfiguration());
            builder.ApplyConfiguration(new PermissionConfiguration());
        }
        public DbSet<Category> Categories {get;set;}
        public DbSet<Permission> Permission {get;set;}

    }
}