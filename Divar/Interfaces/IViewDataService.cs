
using Divar.ViewModels;

namespace Divar.Interfaces
{
    public interface IViewDataService
    {
        Task<HomeViewModel> GetHomeViewDataAsync();
    }
}
