using Divar.Controllers;
using Divar.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace Divar.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LocalizationService(IStringLocalizer<HomeController> localizer, IHttpContextAccessor httpContextAccessor)
        {

            _localizer = localizer;
            _httpContextAccessor = httpContextAccessor;
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

        public string ChangeCultureInfo(string culture)
        {
            // تغییر فرهنگ به فارسی
            //var culture2 = new CultureInfo(culture);

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
            //CultureInfo.CurrentCulture = culture2;
            //CultureInfo.CurrentUICulture = culture2;

            //return "h";
                var cultureInfo = new CultureInfo(culture);

                // تنظیم زبان جاری
                CultureInfo.CurrentCulture = cultureInfo;
                CultureInfo.CurrentUICulture = cultureInfo;
                // ذخیره زبان در کوکی
                _httpContextAccessor.HttpContext.Response.Cookies.Append("culture", culture, new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1),
                    HttpOnly = true,
                    Secure = false // برای HTTPS مقدار true باشد
                });

                return culture;
        }
    }
}
