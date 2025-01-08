using Divar.Db;

namespace Divar.Interfaces
{
    public interface IAdvertisementService
    {
        //Task<List<Category>> GetCategoriesAsync();
        Task<List<Advertisement>> GetAllAdvertisementsAsync();
        Task<List<Advertisement>> SearchAdvertisementsAsync(string searchString);
        Task<Advertisement> CreateAdvertisementAsync(Advertisement model);
    }
}
