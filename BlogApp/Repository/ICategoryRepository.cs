using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Repository
{
  public  interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategory();
        Task<List<Category>> GetCategories();

        Task<int> AddCategory(Category category);
        Task UpdateCategory(Category category);
       // Task<List><Category>>GetCategories();
    }
}
