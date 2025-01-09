using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Service.Interface
{
    public interface ICategoryService
    {
        IQueryable<Category> All(string search, string currentOrder);
    }
}