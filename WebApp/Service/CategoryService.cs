using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.Dto.Category;
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
        private readonly IMapper _mapper;
        
        /// <summary>
        /// Constructor de la clase CategoryService.
        /// </summary>
        /// <param name="context">Contexto de la base de datos.</param>
        public CategoryService(Context context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        /// <summary>
        /// Crea una nueva categoría.
        /// </summary>
        /// <param name="categoryInDto">DTO de entrada con los datos de la categoría.</param>
        /// <returns>DTO de salida con los datos de la categoría creada, o null si la operación falla.</returns>
        public async Task<CategoryOutDto?> Create(CategoryInDto categoryInDto)
        {
            // Mapea el DTO de entrada a la entidad Category.
            var category = _mapper.Map<Category>(categoryInDto);
            
            // Genera un nuevo ID para la categoría.
            category.Id = Guid.NewGuid();
            
            // Agrega la nueva categoría al contexto.
            this._context.Categories.Add(category);
            
            // Guarda los cambios en la base de datos de manera asíncrona.
            var result = await this._context.SaveChangesAsync();
            
            // Si no se guardaron cambios, retorna null.
            if(result == 0) return null;
            
            // Mapea la entidad Category a un DTO de salida.
            var categoryOutDto = _mapper.Map<CategoryOutDto>(category);
            
            // Retorna el DTO de salida.
            return categoryOutDto;
        }

        public async Task<CategoryDetailsDto?> FindById(Guid id)
        {
            var category = _mapper.Map<CategoryDetailsDto>(await Found(id));
            return category;
        }
        private async Task<Category?> Found(Guid id)
        {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        return category;
        }
    }
}