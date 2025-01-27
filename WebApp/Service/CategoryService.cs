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

        /// <summary>
        /// Elimina una categoría por su ID.
        /// </summary>
        /// <param name="id">ID de la categoría a eliminar.</param>
        public async void Destroy(Guid id)
        {
            // Busca la categoría por ID.
            var category = await this.Found(id);
            
            // Si la categoría existe, la elimina del contexto.
            if (category != null)
            {
                this._context.Categories.Remove(category);
            }
            
            // Guarda los cambios en la base de datos de manera asíncrona.
            await this._context.SaveChangesAsync();
        }

        /// <summary>
        /// Edita una categoría existente.
        /// </summary>
        /// <param name="id">ID de la categoría a editar.</param>
        /// <returns>DTO de edición de la categoría, o null si no se encuentra.</returns>
        public async Task<CategoryEditDto?> Edit(Guid id)
        {
            // Busca la categoría por ID y la mapea a un DTO de edición.
            var category = _mapper.Map<CategoryEditDto>(await this.Found(id));
            return category;
        }

        /// <summary>
        /// Verifica si una categoría existe.
        /// </summary>
        /// <param name="id">ID de la categoría a verificar.</param>
        /// <returns>True si la categoría existe, false en caso contrario.</returns>
        public bool Exists(Guid id)
        {
            // Verifica si alguna categoría en el contexto tiene el ID especificado.
            return (_context.Categories?.Any(c => c.Id == id)).GetValueOrDefault();
        }

        /// <summary>
        /// Encuentra una categoría por su ID.
        /// </summary>
        /// <param name="id">ID de la categoría a encontrar.</param>
        /// <returns>DTO con los detalles de la categoría, o null si no se encuentra.</returns>
        public async Task<CategoryDetailsDto?> FindById(Guid id)
        {
            // Busca la categoría por ID y la mapea a un DTO de detalles.
            var category = _mapper.Map<CategoryDetailsDto>(await Found(id));
            return category;
        }

        /// <summary>
        /// Actualiza una categoría existente.
        /// </summary>
        /// <param name="categoryEditDto">DTO de edición con los datos actualizados de la categoría.</param>
        /// <returns>DTO de edición de la categoría actualizada, o null si la operación falla.</returns>
        public async Task<CategoryEditDto?> Update(CategoryEditDto categoryEditDto)
        {
            // Mapea el DTO de edición a la entidad Category.
            var category = _mapper.Map<Category>(categoryEditDto);
            
            // Actualiza la categoría en el contexto.
            _context.Categories.Update(category);
            
            // Guarda los cambios en la base de datos de manera asíncrona.
            var result = await _context.SaveChangesAsync();

            // Si no se guardaron cambios, retorna null.
            if(result == 0) return null;
            
            // Mapea la entidad Category actualizada a un DTO de edición.
            var category_out = _mapper.Map<CategoryEditDto>(category);
            
            // Retorna el DTO de edición de la categoría actualizada.
            return category_out;
        }

        /// <summary>
        /// Busca una categoría por su ID.
        /// </summary>
        /// <param name="id">ID de la categoría a buscar.</param>
        /// <returns>La entidad Category si se encuentra, o null si no se encuentra.</returns>
        private async Task<Category?> Found(Guid id)
        {
            // Busca la primera categoría que coincida con el ID especificado.
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            return category;
        }
    }
}