using Divar.Db;
using Divar.Mapper;
using Divar.ViewModels;

namespace Divar.Interfaces
{
    public interface IAdvertisementService
    {
        Task<Advertisement> GetAdvertisementByIdAsync(int id);
        Task<HomeEditViewModel> GetAdvertisementByIdAsyncHomeEditVM(int id);
        Task<IEnumerable<HomeViewModel>> GetAllAdvertisementsAsyncHomeVM();
        Task<IEnumerable<HomeDetailsViewModel>> GetAllAdvertisementsAsyncHomeDetailsVM();
        Task AddAdvertisementAsync(AddViewModel advertisement);
        Task<Advertisement> UpdateAdvertisementAsync(HomeEditViewModel model);
        Task DeleteAdvertisementAsync(int id);

        //Task<List<Advertisement>> GetAllAdvertisementsAsync();

        Task<List<Advertisement>> SearchAdvertisementsAsync(string searchString);

        //Task<Advertisement> CreateAdvertisementAsync(Advertisement model);
    }
}
