using Divar.Db;

namespace Divar.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<List<Category>> GetBreadcrumbsAsync(int categoryId);
    }
}
