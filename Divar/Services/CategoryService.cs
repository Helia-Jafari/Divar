using Divar.Db;
using Divar.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Divar.Services

{
    public class CategoryService : ICategoryService
    {
        private readonly DivarContext _context;

        public CategoryService(DivarContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<List<Category>> GetBreadcrumbsAsync(int categoryId)
        {
            List<Category> breadcrumbs = new List<Category>();
            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
            breadcrumbs.Add(category);

            while (category.ParentId != null)
            {
                category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == category.ParentId);
                breadcrumbs.Add(category);
            }

            return breadcrumbs;


        }
    }
}
