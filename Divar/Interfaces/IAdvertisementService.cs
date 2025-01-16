using Divar.Db;
using Divar.ViewModels;

namespace Divar.Interfaces
{
    public interface IAdvertisementService
    {
        Task<Advertisement> GetAdvertisementByIdAsync(int id);
        Task<IEnumerable<HomeViewModel>> GetAllAdvertisementsAsyncHomeVM();
        Task AddAdvertisementAsync(AddViewModel advertisement);
        Task UpdateAdvertisementAsync(Advertisement advertisement);
        Task DeleteAdvertisementAsync(int id);

        //Task<List<Advertisement>> GetAllAdvertisementsAsync();

        Task<List<Advertisement>> SearchAdvertisementsAsync(string searchString);

        //Task<Advertisement> CreateAdvertisementAsync(Advertisement model);
    }
}
