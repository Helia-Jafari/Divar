﻿
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

namespace Divar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DivarContext _context;
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly IViewDataService _viewDataService;

        private readonly IAdvertisementService _advertisementService;
        private readonly ICityService _cityService;
        private readonly ICategoryService _categoryService;

        List<List<Category>> cats = new List<List<Category>>();
        Dictionary<string, List<Category>> catsDictionary = new Dictionary<string, List<Category>>();
        //catsDictionary.Add("aa", "aa");
        //catsDictionary["uuu"] = "jjj";

        //public List<Category> categories;

        public HomeController(ILogger<HomeController> logger, DivarContext db, IStringLocalizer<HomeController> localizer, ICityService cityService, ICategoryService categoryService, IAdvertisementService advertisementService, IViewDataService viewDataService)
        {
            _context = db;
            _logger = logger;
            _localizer = localizer;
            _viewDataService = viewDataService;

            _cityService = cityService;
            _categoryService = categoryService;
            _advertisementService = advertisementService;
            //categories = _context.Categories.ToList<Category>();
        }

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

            // دریافت داده‌ها از سرویس
            var homeViewModel = await _viewDataService.GetHomeViewDataAsync();

            // ارسال داده‌ها به ViewData
            ViewData["TitleHomeViewData"] = homeViewModel.TitleHome;
            ViewData["ColorHomeViewData"] = homeViewModel.ColorHome;
            ViewData["BasePriceHomeViewData"] = homeViewModel.BasePriceHome;
            ViewData["FunctionKilometersHomeViewData"] = homeViewModel.FunctionKilometersHome;
            ViewData["CityHomeViewData"] = homeViewModel.CityHome;
            ViewData["currentDate"] = homeViewModel.CurrentDate;
            //ViewData["currentDate"] = DateTime.Now.ToString("D", new CultureInfo("fa-IR"));
            //ViewData["currentDate"] = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            ViewData["SearchHomeViewData"] = homeViewModel.SearchHome;
            ViewData["SucceededSearch"] = homeViewModel.SucceededSearch;
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

            var Viesws = await _advertisementService.GetAllAdvertisementsAsync();
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string SearchString)
        {

            // دریافت داده‌ها از سرویس
            var homeViewModel = await _viewDataService.GetHomeViewDataAsync();

            // ارسال داده‌ها به ViewData
            ViewData["TitleHomeViewData"] = homeViewModel.TitleHome;
            ViewData["ColorHomeViewData"] = homeViewModel.ColorHome;
            ViewData["BasePriceHomeViewData"] = homeViewModel.BasePriceHome;
            ViewData["FunctionKilometersHomeViewData"] = homeViewModel.FunctionKilometersHome;
            ViewData["CityHomeViewData"] = homeViewModel.CityHome;
            ViewData["currentDate"] = homeViewModel.CurrentDate;
            //ViewData["currentDate"] = DateTime.Now.ToString("D", new CultureInfo("fa-IR"));
            //ViewData["currentDate"] = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            ViewData["SearchHomeViewData"] = homeViewModel.SearchHome;
            ViewData["SucceededSearch"] = homeViewModel.SucceededSearch;
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

            var memberList = await _advertisementService.GetAllAdvertisementsAsync();
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

                return View("Index", ads);
            }


            return View("Index", memberList);

        }

        public async Task<IActionResult> ChangeCulture(string culture)
        {

            // دریافت داده‌ها از سرویس
            var homeViewModel = await _viewDataService.GetHomeViewDataAsync();

            // ارسال داده‌ها به ViewData
            ViewData["TitleHomeViewData"] = homeViewModel.TitleHome;
            ViewData["ColorHomeViewData"] = homeViewModel.ColorHome;
            ViewData["BasePriceHomeViewData"] = homeViewModel.BasePriceHome;
            ViewData["FunctionKilometersHomeViewData"] = homeViewModel.FunctionKilometersHome;
            ViewData["CityHomeViewData"] = homeViewModel.CityHome;
            ViewData["currentDate"] = homeViewModel.CurrentDate;
            //ViewData["currentDate"] = DateTime.Now.ToString("D", new CultureInfo("fa-IR"));
            //ViewData["currentDate"] = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            ViewData["SearchHomeViewData"] = homeViewModel.SearchHome;
            ViewData["SucceededSearch"] = homeViewModel.SucceededSearch;
            //ViewData["HomeMenueLayouteViewData"] = _localizer["HomeMenueLayoute"];
            //ViewData["AddAdMenueLayouteViewData"] = _localizer["AddAdMenueLayoute"];


            var Viesws = await _advertisementService.GetAllAdvertisementsAsync();
            foreach (var ad in Viesws)
            {
                var breadcrumbs = await _categoryService.GetBreadcrumbsAsync((int)ad.CategoryId);

                ViewData["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;
                catsDictionary["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;
                this.cats.Add(breadcrumbs);

                var city = await _cityService.GetCityByIdAsync((int)ad.CityId);
                ViewData["city" + ad.Id.ToString()] = city.Name;
            }

            //// تغییر فرهنگ به فارسی
            CultureInfo.CurrentCulture = new CultureInfo(culture);
            CultureInfo.CurrentUICulture = new CultureInfo(culture);

            // تغییر فرهنگ به فارسی
            //CultureInfo.CurrentCulture = new CultureInfo("fa-IR");
            //CultureInfo.CurrentUICulture = new CultureInfo("fa-IR");

            // هدایت به صفحه اصلی پس از تغییر فرهنگ
            return View("Index", Viesws);
        }
    }
}
