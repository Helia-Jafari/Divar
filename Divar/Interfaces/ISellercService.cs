using Divar.Db;
using Divar.ViewModels;

namespace Divar.Interfaces
{
    public interface ISellercService
    {
        Task<IEnumerable<SellerViewModel>> GetAllSellersAsyncSellerVM();
        Task<List<Seller>> SearchSellersAsync(string SearchString);
        Task AddSellerAsync(SellerSignUpViewModel model);
        Task LogInSellerAsync(string nationalcode);
        Task<SellerDetailsViewModel> GetSellerByIdAsyncSellerDetailsVM(int id);
        Task DeleteSellerAsync(int id);
        Task<Seller> UpdateSellerAsync(SellerEditViewModel model);
        Task<SellerEditViewModel> GetSellerByIdAsyncSellerEditVM(int id);
    }
}
