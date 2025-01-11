using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Dto.Category;
using WebApp.Models;

namespace WebApp.Service.Interface
{
    public interface ICategoryService
    {
        IQueryable<Category> All(string search, string currentOrder);
        Task<CategoryOutDto?> Create(CategoryInDto categoryInDto);
        Task<CategoryDetailsDto?> FindById(Guid id);
        Task<CategoryEditDto?> Edit(Guid id);
        Task<CategoryEditDto?> Update(CategoryEditDto categoryEditDto);
        bool Exists(Guid id);
        void Destroy(Guid id);
    }
}