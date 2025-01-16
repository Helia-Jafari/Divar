using Divar.Controllers;
using Divar.Interfaces;
using Divar.ViewModels;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace Divar.Services
{
    public class ViewDataService : IViewDataService
    {
        private readonly IStringLocalizer<HomeController> _HomeControllerLocalizer;

        public ViewDataService(IStringLocalizer<HomeController> HomeControllerLocalizer)
        {
            _HomeControllerLocalizer = HomeControllerLocalizer;
        }

        public async Task<HomeViewModel> GetHomeViewDataAsync()
        {
            var homeViewModel = new HomeViewModel
            {
                //TitleHome = _HomeControllerLocalizer["TitleHome"],
                //ColorHome = _HomeControllerLocalizer["ColorHome"],
                //BasePriceHome = _HomeControllerLocalizer["BasePriceHome"],
                //FunctionKilometersHome = _HomeControllerLocalizer["FunctionKilometersHome"],
                //CityHome = _HomeControllerLocalizer["CityIdHome"],
                //CurrentDate = DateTime.Now.ToString("D", CultureInfo.CurrentCulture),
                //SearchHome = _HomeControllerLocalizer["SearchHome"],
                //SucceededSearch = _HomeControllerLocalizer["SucceededSearch"]
            };

            return await Task.FromResult(homeViewModel);
            // بازگشت داده‌ها به صورت async
        }
    }
}
