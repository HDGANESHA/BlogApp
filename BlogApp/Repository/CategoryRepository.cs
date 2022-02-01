using BlogApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DemoBlogDBContext _context;

        public CategoryRepository(DemoBlogDBContext context)
        {
            _context = context;
        }

      

        public async Task<int> AddCategory(Category category)
        {
            if (_context != null)
            {
                await _context.Category.AddAsync(category);
                await _context.SaveChangesAsync();
                return category.Id;
            }
            return 0;
        }

        public async Task<List<Category>> GetAllCategory()
        {
            if (_context != null)
            { //lambda expression
                return await _context.Category.ToListAsync();
            }
            return null;
        }

        public async Task<List<Category>> GetCategories()
        {
            if (_context != null)
            {
                return await _context.Category.Include(p=>p.Post).ToListAsync();
            }
            return null;
        }

       
        public async Task UpdateCategory(Category category)
        {

            if (_context != null)
            {
                _context.Entry(category).State = EntityState.Modified;
                _context.Category.Update(category);

                await _context.SaveChangesAsync();
            }

        }


    }
}
