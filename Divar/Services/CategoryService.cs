using Divar.Db;
using Divar.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

namespace Divar.Services

{
    public class CategoryService : ICategoryService
    {
        private readonly DivarContext _context;
        private readonly IMemoryCache _cache;
        //private readonly IDistributedCache _cache;

        public CategoryService(DivarContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        //public async Task<List<Category>> GetCategoriesAsync()
        //{
        //    const string cacheKey = "categories";
        //    if (!_cache.TryGetValue(cacheKey, out List<Category> categories))
        //    {
        //        categories = await _context.Categories.ToListAsync();
        //        _cache.Set(cacheKey, categories, TimeSpan.FromMinutes(10)); // مدت زمان کشینگ
        //    }
        //    return categories;
        //}

        public async Task<List<Category>> GetBreadcrumbsAsync(int categoryId)
        {
            string cacheKey = $"breadcrumbs_{categoryId}";
            if (!_cache.TryGetValue(cacheKey, out List<Category> categories))
            {
                categories = new List<Category>();
                Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
                categories.Add(category);
                while (category.ParentId != null)
                {
                    category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == category.ParentId);
                    categories.Add(category);
                }
                _cache.Set(cacheKey, categories, TimeSpan.FromMinutes(10)); // مدت زمان کشینگ
            }
            return categories;

            //string cacheKey = $"breadcrumbs_{categoryId}";
            //var cachedData = await _cache.GetStringAsync(cacheKey);
            //if (cachedData.IsNullOrEmpty())
            //{
            //    List<Category> cachedBreadcrumbs = new List<Category>();
            //    Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
            //    cachedBreadcrumbs.Add(category);
            //    while (category.ParentId != null)
            //    {
            //        category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == category.ParentId);
            //        cachedBreadcrumbs.Add(category);
            //    }
            //    var serializedBreadcrumbs = JsonSerializer.Serialize(cachedBreadcrumbs);
            //    await _cache.SetStringAsync(cacheKey, serializedBreadcrumbs, new DistributedCacheEntryOptions
            //    {
            //        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            //    });
            //    return cachedBreadcrumbs;
            //}
            //var cachedBreadcrumb = JsonSerializer.Deserialize<List<Category>>(cachedData);
            //return cachedBreadcrumb;




        }
    }
}
