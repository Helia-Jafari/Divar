using Divar.ViewModels;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace Divar.Services
{
    public class ViewDataService
    {
        private readonly IStringLocalizer _localizer;

        public ViewDataService(IStringLocalizer localizer)
        {
            _localizer = localizer;
        }

        public async Task<HomeViewModel> GetHomeViewDataAsync()
        {
            var homeViewModel = new HomeViewModel
            {
                TitleHome = _localizer["TitleHome"],
                ColorHome = _localizer["ColorHome"],
                BasePriceHome = _localizer["BasePriceHome"],
                FunctionKilometersHome = _localizer["FunctionKilometersHome"],
                CityHome = _localizer["CityIdHome"],
                CurrentDate = DateTime.Now.ToString("D", CultureInfo.CurrentCulture),
                SearchHome = _localizer["SearchHome"],
                SucceededSearch = _localizer["SucceededSearch"]
            };

            return await Task.FromResult(homeViewModel);
            // بازگشت داده‌ها به صورت async
        }
    }
}
