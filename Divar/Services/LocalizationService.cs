using Divar.Controllers;
using Divar.Interfaces;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace Divar.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IStringLocalizer<HomeController> _localizer;
       public LocalizationService(IStringLocalizer<HomeController> localizer)
        {

            _localizer = localizer;
        }
        public string GetLocalizedDir()
        {
            if (CultureInfo.CurrentCulture.ToString() == "fa-IR")
            {
                return "rtl";
            }
            else
            {
                return "ltr";
            }
        }
        public string GetlocalizedBootstrapLink()
        {
            if (CultureInfo.CurrentCulture.ToString() == "fa-IR")
            {
                return "/lib/bootstrap/dist/css/bootstrap.rtl.min.css";
            }
            else
            {
                return "/lib/bootstrap/dist/css/bootstrap.min.css";
            }
        }

        public string GetLocalizedString(string key)
        {
            return _localizer[key];
        }
    }
}
