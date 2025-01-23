
using Divar.Db;
using Divar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Divar.Interfaces;
using Divar.Services;
using System.Text.RegularExpressions;
using Divar.Mapper;
using Divar.ViewModels;

namespace Divar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DivarContext _context;
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly ILocalizationService _localizationService;
        //private readonly IViewDataService _viewDataService;

        private readonly IAdvertisementService _advertisementService;
        private readonly ICityService _cityService;
        private readonly ICategoryService _categoryService;

        List<List<Category>> cats = new List<List<Category>>();
        Dictionary<string, List<Category>> catsDictionary = new Dictionary<string, List<Category>>();
        //catsDictionary.Add("aa", "aa");
        //catsDictionary["uuu"] = "jjj";

        //public List<Category> categories;

        //private readonly AdvertisementMapper _advertisementMapper;

        public HomeController(ILogger<HomeController> logger, DivarContext db, IStringLocalizer<HomeController> localizer, ICityService cityService, ICategoryService categoryService, IAdvertisementService advertisementService, IViewDataService viewDataService, ILocalizationService localizationService)
        {
            _context = db;
            _logger = logger;
            _localizer = localizer;
            //_viewDataService = viewDataService;

            _cityService = cityService;
            _categoryService = categoryService;
            _advertisementService = advertisementService;
            _localizationService = localizationService;
            //categories = _context.Categories.ToList<Category>();

            //_advertisementMapper = advertisementMapper;
        }

        [HttpGet("")]
        [HttpGet("Home")]
        public async Task<IActionResult> Index()
        {


            //foreach (var item in _context.Advertisements.ToList())
            //{
            //    var view = new ViwShowAdvertisement
            //    {
            //        Title=item.Title,
            //        BasePrice=item.BasePrice,
            //        FunctionKilometers=item.FunctionKilometers,
            //        Id=item.Id
            //    };
            //    _context.ViwShowAdvertisements.Add(view);
            //}

            //// دریافت داده‌ها از سرویس
            //var homeViewModel = await _viewDataService.GetHomeViewDataAsync();

            //// ارسال داده‌ها به ViewData
            //ViewData["TitleHomeViewData"] = homeViewModel.TitleHome;
            //ViewData["ColorHomeViewData"] = homeViewModel.ColorHome;
            //ViewData["BasePriceHomeViewData"] = homeViewModel.BasePriceHome;
            //ViewData["FunctionKilometersHomeViewData"] = homeViewModel.FunctionKilometersHome;
            //ViewData["CityHomeViewData"] = homeViewModel.CityHome;
            //ViewData["currentDate"] = homeViewModel.CurrentDate;
            ////ViewData["currentDate"] = DateTime.Now.ToString("D", new CultureInfo("fa-IR"));
            ////ViewData["currentDate"] = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            //ViewData["SearchHomeViewData"] = homeViewModel.SearchHome;
            //ViewData["SucceededSearch"] = homeViewModel.SucceededSearch;
            ////ViewData["HomeMenueLayouteViewData"] = _localizer["HomeMenueLayoute"];
            ////ViewData["AddAdMenueLayouteViewData"] = _localizer["AddAdMenueLayoute"];


            // ارسال داده‌ها به ViewData
            ViewData["TitleHomeViewData"] = _localizer["TitleHome"];
            ViewData["ColorHomeViewData"] = _localizer["ColorHome"];
            ViewData["BasePriceHomeViewData"] = _localizer["BasePriceHome"];
            ViewData["FunctionKilometersHomeViewData"] = _localizer["FunctionKilometersHome"];
            ViewData["CityHomeViewData"] = _localizer["CityIdHome"];
            ViewData["currentDate"] = DateTime.Now.ToString("D", CultureInfo.CurrentCulture);
            //ViewData["currentDate"] = DateTime.Now.ToString("D", new CultureInfo("fa-IR"));
            //ViewData["currentDate"] = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            ViewData["SearchHomeViewData"] = _localizer["SearchHome"];
            ViewData["SucceededSearch"] = _localizer["SucceededSearch"];
            //ViewData["HomeMenueLayouteViewData"] = _localizer["HomeMenueLayoute"];
            //ViewData["AddAdMenueLayouteViewData"] = _localizer["AddAdMenueLayoute"];


            //switch (CultureInfo.CurrentCulture.ToString())
            //{
            //    case "en-US":
            //        ViewData["dir"] = "ltr";
            //        break;
            //    case "fa-IR":
            //        ViewData["dir"] = "rtl";
            //        break;
            //}
            //if (CultureInfo.CurrentCulture.ToString() == "fa-IR")
            //{
            //    ViewData["dir"] = "rtl";
            //} else
            //{
            //    ViewData["dir"] = "ltr";
            //}

            var Viesws = await _advertisementService.GetAllAdvertisementsAsyncHomeVM();
            foreach (var ad in Viesws)
            {
                var breadcrumbs = await _categoryService.GetBreadcrumbsAsync((int)ad.CategoryId);

                ViewData["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;
                catsDictionary["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;
                this.cats.Add(breadcrumbs);

                var city = await _cityService.GetCityByIdAsync((int)ad.CityId);
                ViewData["city" + ad.Id.ToString()] = city.Name;
            }



            return View("Index", Viesws);


        }
    

        [HttpGet("details/{id}")]
        [HttpGet("ads/details/{id}")]
        [HttpGet("ads/{id:int:min(1)}")]
        [HttpGet("advertisements/details/{id}")]
        [HttpGet("advertisements/{id:int:min(1)}")]
        public async Task<IActionResult> Details(int id)
        {
            // ارسال داده‌ها به ViewData
            ViewData["TitleHomeViewData"] = _localizer["TitleHome"];
            ViewData["ColorHomeViewData"] = _localizer["ColorHome"];
            ViewData["BasePriceHomeViewData"] = _localizer["BasePriceHome"];
            ViewData["FunctionKilometersHomeViewData"] = _localizer["FunctionKilometersHome"];
            ViewData["CityHomeViewData"] = _localizer["CityIdHome"];
            ViewData["CaegoryHomeViewData"] = _localizer["CategoryIdHome"];
            ViewData["ChassisAndBodyConditionHomeViewData"] = _localizer["ChassisAndBodyConditionHome"];
            ViewData["DoYouWantToReplaceHomeViewData"] = _localizer["DoYouWantToReplaceHome"];
            ViewData["EngineConditionHomeViewData"] = _localizer["EngineConditionHome"];
            ViewData["FrontChassisConditionHomeViewData"] = _localizer["FrontChassisConditionHome"];
            ViewData["FunctionKilometersHomeViewData"] = _localizer["FunctionKilometersHome"];
            ViewData["GearboxHomeViewData"] = _localizer["GearboxHome"];
            ViewData["IsTheChatActivatedHomeViewData"] = _localizer["IsTheChatActivatedHome"];
            ViewData["IsThePhoneCallActiveHomeViewData"] = _localizer["IsThePhoneCallActiveHome"];
            ViewData["ItsModelHomeViewData"] = _localizer["ItsModelHome"];
            ViewData["RearChassisConditionHomeViewData"] = _localizer["RearChassisConditionHome"];
            ViewData["ThirdPartyInsuranceTermHomeViewData"] = _localizer["ThirdPartyInsuranceTermHome"]; 
            ViewData["SearchHomeViewData"] = _localizer["SearchHome"]; 
            ViewData["currentDate"] = DateTime.Now.ToString("D", CultureInfo.CurrentCulture);
            //ViewData["currentDate"] = DateTime.Now.ToString("D", new CultureInfo("fa-IR"));
            //ViewData["currentDate"] = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            ViewData["SearchHomeViewData"] = _localizer["SearchHome"];
            ViewData["SucceededSearch"] = _localizer["SucceededSearch"];
            //ViewData["HomeMenueLayouteViewData"] = _localizer["HomeMenueLayoute"];
            //ViewData["AddAdMenueLayouteViewData"] = _localizer["AddAdMenueLayoute"];

            var Views = await _advertisementService.GetAllAdvertisementsAsyncHomeDetailsVM();
            //var ads = await _context.Advertisements.ToListAsync();
            var ad = Views.FirstOrDefault(a => a.Id == id);
            if (ad == null)
            {
                return NotFound("محصولی با این شناسه یافت نشد.");
            }

            return View(ad);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _advertisementService.DeleteAdvertisementAsync(id);

            var Viesws = await _advertisementService.GetAllAdvertisementsAsyncHomeVM();
            foreach (var ad in Viesws)
            {
                var breadcrumbs = await _categoryService.GetBreadcrumbsAsync((int)ad.CategoryId);

                ViewData["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;
                catsDictionary["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;
                this.cats.Add(breadcrumbs);

                var city = await _cityService.GetCityByIdAsync((int)ad.CityId);
                ViewData["city" + ad.Id.ToString()] = city.Name;
            }
            return View("Index", Viesws);
        }
        
        [HttpGet("edit/{id}")]
        [HttpGet("advertisements/edit/{id:int:min(1)}")]
        [HttpGet("ads/edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            // ارسال داده‌ها به ViewData
            ViewData["TitleHomeViewData"] = _localizer["TitleHome"];
            ViewData["BrandHomeViewData"] = _localizer["BrandHome"];
            ViewData["DescriptionHomeViewData"] = _localizer["DescriptionHome"];
            ViewData["ColorHomeViewData"] = _localizer["ColorHome"];
            ViewData["BasePriceHomeViewData"] = _localizer["BasePriceHome"];
            ViewData["FunctionKilometersHomeViewData"] = _localizer["FunctionKilometersHome"];
            ViewData["CityHomeViewData"] = _localizer["CityIdHome"];
            ViewData["CaegoryHomeViewData"] = _localizer["CategoryIdHome"];
            ViewData["ChassisAndBodyConditionHomeViewData"] = _localizer["ChassisAndBodyConditionHome"];
            ViewData["DoYouWantToReplaceHomeViewData"] = _localizer["DoYouWantToReplaceHome"];
            ViewData["EngineConditionHomeViewData"] = _localizer["EngineConditionHome"];
            ViewData["FrontChassisConditionHomeViewData"] = _localizer["FrontChassisConditionHome"];
            ViewData["FunctionKilometersHomeViewData"] = _localizer["FunctionKilometersHome"];
            ViewData["GearboxHomeViewData"] = _localizer["GearboxHome"];
            ViewData["IsTheChatActivatedHomeViewData"] = _localizer["IsTheChatActivatedHome"];
            ViewData["IsThePhoneCallActiveHomeViewData"] = _localizer["IsThePhoneCallActiveHome"];
            ViewData["ItsModelHomeViewData"] = _localizer["ItsModelHome"];
            ViewData["RearChassisConditionHomeViewData"] = _localizer["RearChassisConditionHome"];
            ViewData["ThirdPartyInsuranceTermHomeViewData"] = _localizer["ThirdPartyInsuranceTermHome"];
            ViewData["NationalityHomeViewData"] = _localizer["NationalityHome"];
            ViewData["NationalCodeHomeViewData"] = _localizer["NationalCodeHome"];
            ViewData["SubmitHomeViewData"] = _localizer["SubmitHome"];
            ViewData["currentDate"] = DateTime.Now.ToString("D", CultureInfo.CurrentCulture);
            //ViewData["currentDate"] = DateTime.Now.ToString("D", new CultureInfo("fa-IR"));
            //ViewData["currentDate"] = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            ViewData["SearchHomeViewData"] = _localizer["SearchHome"];
            ViewData["SucceededSearch"] = _localizer["SucceededSearch"];
            //ViewData["HomeMenueLayouteViewData"] = _localizer["HomeMenueLayoute"];
            //ViewData["AddAdMenueLayouteViewData"] = _localizer["AddAdMenueLayoute"];



            List<Category> categories;
        categories = await _context.Categories.ToListAsync<Category>();
            List<Category> cs = new List<Category>();
            foreach (var item in categories)
            {
                cs.Add(item);
            }

            ViewData["categories"] = cs;

            var view = await _advertisementService.GetAdvertisementByIdAsyncHomeEditVM(id);
            if (view == null) return NotFound();
            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HomeEditViewModel model)
        {
            // ارسال داده‌ها به ViewData
            ViewData["TitleHomeViewData"] = _localizer["TitleHome"];
            ViewData["ColorHomeViewData"] = _localizer["ColorHome"];
            ViewData["BasePriceHomeViewData"] = _localizer["BasePriceHome"];
            ViewData["FunctionKilometersHomeViewData"] = _localizer["FunctionKilometersHome"];
            ViewData["CityHomeViewData"] = _localizer["CityIdHome"];
            ViewData["CaegoryHomeViewData"] = _localizer["CategoryIdHome"];
            ViewData["ChassisAndBodyConditionHomeViewData"] = _localizer["ChassisAndBodyConditionHome"];
            ViewData["DoYouWantToReplaceHomeViewData"] = _localizer["DoYouWantToReplaceHome"];
            ViewData["EngineConditionHomeViewData"] = _localizer["EngineConditionHome"];
            ViewData["FrontChassisConditionHomeViewData"] = _localizer["FrontChassisConditionHome"];
            ViewData["FunctionKilometersHomeViewData"] = _localizer["FunctionKilometersHome"];
            ViewData["GearboxHomeViewData"] = _localizer["GearboxHome"];
            ViewData["IsTheChatActivatedHomeViewData"] = _localizer["IsTheChatActivatedHome"];
            ViewData["IsThePhoneCallActiveHomeViewData"] = _localizer["IsThePhoneCallActiveHome"];
            ViewData["ItsModelHomeViewData"] = _localizer["ItsModelHome"];
            ViewData["RearChassisConditionHomeViewData"] = _localizer["RearChassisConditionHome"];
            ViewData["ThirdPartyInsuranceTermHomeViewData"] = _localizer["ThirdPartyInsuranceTermHome"];
            ViewData["currentDate"] = DateTime.Now.ToString("D", CultureInfo.CurrentCulture);
            //ViewData["currentDate"] = DateTime.Now.ToString("D", new CultureInfo("fa-IR"));
            //ViewData["currentDate"] = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            ViewData["SearchHomeViewData"] = _localizer["SearchHome"];
            ViewData["SucceededSearch"] = _localizer["SucceededSearch"];
            //ViewData["HomeMenueLayouteViewData"] = _localizer["HomeMenueLayoute"];
            //ViewData["AddAdMenueLayouteViewData"] = _localizer["AddAdMenueLayoute"];

            List<Category> categories;
        categories = await _context.Categories.ToListAsync<Category>();
            List<Category> cs = new List<Category>();
            foreach (var item in categories)
            {
                cs.Add(item);
            }

            ViewData["categories"] = cs;







            if (!ModelState.IsValid)
            {
                //Tuple<Advertisement, List<Category>> tuplee = new Tuple<Advertisement, List<Category>>(new Advertisement(), categories);
                return View("Details");
            };
            //Tuple<Advertisement, List<Category>> tuple = new Tuple<Advertisement, List<Category>>(new Advertisement(), categories);



            await _advertisementService.UpdateAdvertisementAsync(model);
            //var ad = await _advertisementService.GetAdvertisementByIdAsync(model.Id);
            var view = await _advertisementService.GetAdvertisementByIdAsyncHomeDetailsVM(model.Id);


            //var ads = await _context.Advertisements.ToListAsync();
            //var ad = ads.FirstOrDefault(a => a.Id == model.Id);

            return View("Details", view);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public IActionResult HomeSearch()
        //{
        //    return View("Index");
        //}


        [HttpPost("")]
        [HttpPost("Home")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string SearchString, string culture)
        {

            //// دریافت داده‌ها از سرویس
            //var homeViewModel = await _viewDataService.GetHomeViewDataAsync();

            //// ارسال داده‌ها به ViewData
            //ViewData["TitleHomeViewData"] = homeViewModel.TitleHome;
            //ViewData["ColorHomeViewData"] = homeViewModel.ColorHome;
            //ViewData["BasePriceHomeViewData"] = homeViewModel.BasePriceHome;
            //ViewData["FunctionKilometersHomeViewData"] = homeViewModel.FunctionKilometersHome;
            //ViewData["CityHomeViewData"] = homeViewModel.CityHome;
            //ViewData["currentDate"] = homeViewModel.CurrentDate;
            ////ViewData["currentDate"] = DateTime.Now.ToString("D", new CultureInfo("fa-IR"));
            ////ViewData["currentDate"] = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            //ViewData["SearchHomeViewData"] = homeViewModel.SearchHome;
            //ViewData["SucceededSearch"] = homeViewModel.SucceededSearch;
            ////ViewData["HomeMenueLayouteViewData"] = _localizer["HomeMenueLayoute"];
            ////ViewData["AddAdMenueLayouteViewData"] = _localizer["AddAdMenueLayoute
            ///



            // ارسال داده‌ها به ViewData
            ViewData["TitleHomeViewData"] = _localizer["TitleHome"];
            ViewData["ColorHomeViewData"] = _localizer["ColorHome"];
            ViewData["BasePriceHomeViewData"] = _localizer["BasePriceHome"];
            ViewData["FunctionKilometersHomeViewData"] = _localizer["FunctionKilometersHome"];
            ViewData["CityHomeViewData"] = _localizer["CityIdHome"];
            ViewData["currentDate"] = DateTime.Now.ToString("D", CultureInfo.CurrentCulture);
            //ViewData["currentDate"] = DateTime.Now.ToString("D", new CultureInfo("fa-IR"));
            //ViewData["currentDate"] = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            ViewData["SearchHomeViewData"] = _localizer["SearchHome"];
            ViewData["SucceededSearch"] = _localizer["SucceededSearch"];
            //ViewData["HomeMenueLayouteViewData"] = _localizer["HomeMenueLayoute"];
            //ViewData["AddAdMenueLayouteViewData"] = _localizer["AddAdMenueLayoute"];




            //switch (CultureInfo.CurrentCulture.ToString())
            //{
            //    case "en-US":
            //        ViewData["dir"] = "ltr";
            //        break;
            //    case "fa-IR":
            //        ViewData["dir"] = "rtl";
            //        break;
            //}
            //if (CultureInfo.CurrentCulture.ToString() == "fa-IR")
            //{
            //    ViewData["dir"] = "rtl";
            //}
            //else
            //{
            //    ViewData["dir"] = "ltr";
            //}

            var memberList = await _advertisementService.GetAllAdvertisementsAsyncHomeVM();
            foreach (var ad in memberList)
            {
                var breadcrumbs = await _categoryService.GetBreadcrumbsAsync((int)ad.CategoryId);

                ViewData["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;
                catsDictionary["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;
                this.cats.Add(breadcrumbs);

                //var citys = await _context.Cities.FirstOrDefaultAsync(cat => cat.Id == ad.CityId);
                var city = await _cityService.GetCityByIdAsync((int)ad.CityId);
                ViewData["city" + ad.Id.ToString()] = city.Name;
            }



            if (!ModelState.IsValid)
            {



                // تغییر فرهنگ به مقداری که از URL گرفته شده است
                if (!string.IsNullOrEmpty(culture))
                {
                    var cultureInfo = new CultureInfo(culture);
                    CultureInfo.CurrentCulture = cultureInfo;
                    CultureInfo.CurrentUICulture = cultureInfo;

                    // ذخیره فرهنگ در کوکی
                    Response.Cookies.Append("culture", cultureInfo.Name, new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddYears(1), // تاریخ انقضا
                        HttpOnly = true, // فقط از طریق HTTP قابل دسترسی
                        SameSite = SameSiteMode.Lax // یا Strict یا None
                    });
                }



                return View("Index", memberList);
            }
            if (!SearchString.IsNullOrEmpty())
            {
                var ads = await _advertisementService.SearchAdvertisementsAsync(SearchString);

                foreach (var ad in ads)
                {
                    var breadcrumbs = await _categoryService.GetBreadcrumbsAsync((int)ad.CategoryId);

                    ViewData["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;
                    catsDictionary["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;
                    this.cats.Add(breadcrumbs);

                    //var city = await _context.Cities.FirstOrDefaultAsync(cat => cat.Id == ad.CityId);
                    var city = await _cityService.GetCityByIdAsync((int)ad.CityId);
                    ViewData["city" + ad.Id.ToString()] = city.Name;
                }



                // تغییر فرهنگ به مقداری که از URL گرفته شده است
                if (!string.IsNullOrEmpty(culture))
                {
                    var cultureInfo = new CultureInfo(culture);
                    CultureInfo.CurrentCulture = cultureInfo;
                    CultureInfo.CurrentUICulture = cultureInfo;

                    // ذخیره فرهنگ در کوکی
                    Response.Cookies.Append("culture", cultureInfo.Name, new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddYears(1), // تاریخ انقضا
                        HttpOnly = true, // فقط از طریق HTTP قابل دسترسی
                        SameSite = SameSiteMode.Lax // یا Strict یا None
                    });
                }



                return View("Index", ads);
            }



            // تغییر فرهنگ به مقداری که از URL گرفته شده است
            if (!string.IsNullOrEmpty(culture))
            {
                var cultureInfo = new CultureInfo(culture);
                CultureInfo.CurrentCulture = cultureInfo;
                CultureInfo.CurrentUICulture = cultureInfo;

                // ذخیره فرهنگ در کوکی
                Response.Cookies.Append("culture", cultureInfo.Name, new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1), // تاریخ انقضا
                    HttpOnly = true, // فقط از طریق HTTP قابل دسترسی
                    SameSite = SameSiteMode.Lax // یا Strict یا None
                });
            }



            return View("Index", memberList);

        }

        public IActionResult ChangeCulture(string culture, string returnUrl)
        {
            // تغییر زبان
            _localizationService.ChangeCultureInfo(culture);

            // بازگشت به صفحه قبلی یا صفحه اصلی
            //return !string.IsNullOrEmpty(returnUrl) ? RedirectToAction(returnUrl) : RedirectToAction("Index", "Home");
            return  RedirectToAction("Index", "Home", new {culture=culture});
        }

        //public async Task<IActionResult> ChangeCulture(string culture, string action)
        //{

        //// دریافت داده‌ها از سرویس
        //var homeViewModel = await _viewDataService.GetHomeViewDataAsync();

        //// ارسال داده‌ها به ViewData
        //ViewData["TitleHomeViewData"] = homeViewModel.TitleHome;
        //ViewData["ColorHomeViewData"] = homeViewModel.ColorHome;
        //ViewData["BasePriceHomeViewData"] = homeViewModel.BasePriceHome;
        //ViewData["FunctionKilometersHomeViewData"] = homeViewModel.FunctionKilometersHome;
        //ViewData["CityHomeViewData"] = homeViewModel.CityHome;
        //ViewData["currentDate"] = homeViewModel.CurrentDate;
        ////ViewData["currentDate"] = DateTime.Now.ToString("D", new CultureInfo("fa-IR"));
        ////ViewData["currentDate"] = DateTime.Now.ToString(CultureInfo.CurrentCulture);
        //ViewData["SearchHomeViewData"] = homeViewModel.SearchHome;
        //ViewData["SucceededSearch"] = homeViewModel.SucceededSearch;
        ////ViewData["HomeMenueLayouteViewData"] = _localizer["HomeMenueLayoute"];
        ////ViewData["AddAdMenueLayouteViewData"] = _localizer["AddAdMenueLayoute"];
        ///



        //// ارسال داده‌ها به ViewData
        //ViewData["TitleHomeViewData"] = _localizer["TitleHome"];
        //ViewData["ColorHomeViewData"] = _localizer["ColorHome"];
        //ViewData["BasePriceHomeViewData"] = _localizer["BasePriceHome"];
        //ViewData["FunctionKilometersHomeViewData"] = _localizer["FunctionKilometersHome"];
        //ViewData["CityHomeViewData"] = _localizer["CityIdHome"];
        //ViewData["currentDate"] = DateTime.Now.ToString("D", CultureInfo.CurrentCulture);
        ////ViewData["currentDate"] = DateTime.Now.ToString("D", new CultureInfo("fa-IR"));
        ////ViewData["currentDate"] = DateTime.Now.ToString(CultureInfo.CurrentCulture);
        //ViewData["SearchHomeViewData"] = _localizer["SearchHome"];
        //ViewData["SucceededSearch"] = _localizer["SucceededSearch"];
        ////ViewData["HomeMenueLayouteViewData"] = _localizer["HomeMenueLayoute"];
        ////ViewData["AddAdMenueLayouteViewData"] = _localizer["AddAdMenueLayoute"];


        //var Viesws = await _advertisementService.GetAllAdvertisementsAsyncHomeVM();
        //foreach (var ad in Viesws)
        //{
        //    var breadcrumbs = await _categoryService.GetBreadcrumbsAsync((int)ad.CategoryId);

        //    ViewData["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;
        //    catsDictionary["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;
        //    this.cats.Add(breadcrumbs);

        //    var city = await _cityService.GetCityByIdAsync((int)ad.CityId);
        //    ViewData["city" + ad.Id.ToString()] = city.Name;
        //}


        //_localizationService.ChangeCultureInfo(culture);


        // هدایت به صفحه اصلی پس از تغییر فرهنگ
        //return RedirectToAction(action, "Home", new { culture = culture });
        //}
    }
}
