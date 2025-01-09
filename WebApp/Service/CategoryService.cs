using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Service.Interface;

namespace WebApp.Service
{
    /// <summary>
    /// Servicio para gestionar las categorías.
    /// </summary>
    public class CategoryService : ICategoryService
    {
        private readonly Context _context;
        
        /// <summary>
        /// Constructor de la clase CategoryService.
        /// </summary>
        /// <param name="context">Contexto de la base de datos.</param>
        public CategoryService(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todas las categorías que coinciden con el criterio de búsqueda.
        /// </summary>
        /// <param name="search">Criterio de búsqueda para filtrar las categorías.</param>
        /// <param name="currentOrder">Orden actual de las categorías.</param>
        /// <returns>Una consulta de categorías que coinciden con el criterio de búsqueda.</returns>
        public IQueryable<Category> All(string search, string currentOrder)
        {
            var categories = _context.Categories.Select(c => c);
            if (!string.IsNullOrEmpty(search))
            {
                categories = categories.Where(c => c.Name.Contains(search));
            }

            return categories;
        }
    }
}