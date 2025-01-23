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

        public void ChangeCultureInfo(string culture)
        {
            // تغییر فرهنگ به فارسی
            var culture2 = new CultureInfo(culture);

            //// تغییر فرهنگ به فارسی
            //var culture2 = new CultureInfo(culture);
            //Console.WriteLine("Setting culture to: " + culture2.Name);

            // ذخیره فرهنگ در کوکی
            //Response.Cookies.Append("culture", culture2.Name, new CookieOptions
            //{
            //    Expires = DateTimeOffset.UtcNow.AddYears(1), // تاریخ انقضا
            //    HttpOnly = true, // فقط در دسترس از طریق HTTP
            //    SameSite = SameSiteMode.Lax, // یا Strict یا None، بستگی به نیاز شما دارد
            //    Secure = false // اگر در محیط امن (https) هستید، true بگذارید
            //});
            //// تغییر فرهنگ برای درخواست جاری
            //CultureInfo.CurrentCulture = culture2;
            //CultureInfo.CurrentUICulture = culture2;

            // تغییر فرهنگ به فارسی
            CultureInfo.CurrentCulture = culture2;
            CultureInfo.CurrentUICulture = culture2;
        }
    }
}
