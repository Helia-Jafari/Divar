
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

        private readonly IAdvertisementService _advertisementService;
        private readonly ICityService _cityService;
        private readonly ICategoryService _categoryService;

        List<List<Category>> cats = new List<List<Category>>();
        Dictionary<string, List<Category>> catsDictionary = new Dictionary<string, List<Category>>();
        //catsDictionary.Add("aa", "aa");
        //catsDictionary["uuu"] = "jjj";

        //public List<Category> categories;

        public HomeController(ILogger<HomeController> logger, DivarContext db, IStringLocalizer<HomeController> localizer, ICityService cityService, ICategoryService categoryService, IAdvertisementService advertisementService)
        {
            _context = db;
            _logger = logger;
            _localizer = localizer;

            _cityService = cityService;
            _categoryService = categoryService;
            _advertisementService = advertisementService;
            //categories = _context.Categories.ToList<Category>();
        }

        public async Task<IActionResult> Index()
        {

            //List<Category> cs = new List<Category>();
            //foreach (var item in categories)
            //{
            //    cs.Add(item);
            //}

            //ViewData["categories"] = cs;


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
            ViewData["TitleHomeViewData"] = _localizer["TitleHome"];
            ViewData["ColorHomeViewData"] = _localizer["ColorHome"];
            ViewData["BasePriceHomeViewData"] = _localizer["BasePriceHome"];
            ViewData["FunctionKilometersHomeViewData"] = _localizer["FunctionKilometersHome"];
            ViewData["CityHomeViewData"] = _localizer["CityIdHome"];
            //ViewData["currentDate"] = DateTime.Now.ToString("D", new CultureInfo("fa-IR"));
            //ViewData["currentDate"] = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            ViewData["currentDate"] = DateTime.Now.ToString("D",CultureInfo.CurrentCulture);
            ViewData["SearchHomeViewData"] = _localizer["SearchHome"];
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

                //var citys = await _context.Cities.FirstOrDefaultAsync(cat => cat.Id == ad.CityId);
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

            ViewData["SucceededSearch"] = _localizer["SucceededSearch"];
            ViewData["TitleHomeViewData"] = _localizer["TitleHome"];
            ViewData["ColorHomeViewData"] = _localizer["ColorHome"];
            ViewData["BasePriceHomeViewData"] = _localizer["BasePriceHome"];
            ViewData["FunctionKilometersHomeViewData"] = _localizer["FunctionKilometersHome"];
            ViewData["CityHomeViewData"] = _localizer["CityIdHome"];
            //ViewData["currentDate"] = DateTime.Now.ToString("D", new CultureInfo("fa-IR"));
            //ViewData["currentDate"] = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            ViewData["currentDate"] = DateTime.Now.ToString("D", CultureInfo.CurrentCulture);
            ViewData["SearchHomeViewData"] = _localizer["SearchHome"];



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

                SearchString = SearchString.Trim();


                //var ads = await _context.Advertisements
                //    .Where(m => m.Title.Contains(SearchString) ||
                //    m.Color.Contains(SearchString) ||
                //    m.BasePrice.ToString().Contains(SearchString) ||
                //    m.FunctionKilometers.ToString().Contains(SearchString) ||
                //    _context.Categories.Where(a => a.Id == m.CategoryId).FirstOrDefault().Title.Contains(SearchString) ||
                //    _context.Cities.Where(city => city.Id == m.CityId).FirstOrDefault().Name.Contains(SearchString))
                //    .ToListAsync();

                //var ads = await _context.Advertisements
                //    .Where(async m => m.Title.Contains(SearchString) || 
                //    m.Color.Contains(SearchString) || 
                //    m.BasePrice.ToString().Contains(SearchString) || 
                //    m.FunctionKilometers.ToString().Contains(SearchString) || 
                //    await _context.Categories.Where(a => a.Id == m.CategoryId).FirstOrDefaultAsync().Title.Contains(SearchString) || 
                //    await _context.Cities.Where(city => city.Id == m.CityId).FirstOrDefaultAsync().Name.Contains(SearchString))
                //    .ToListAsync();

                //var categories = await _context.Categories.ToListAsync();
                //var cities = await _context.Cities.ToListAsync();
                //var ads = await _context.Advertisements.Where(m =>
                //    m.Title.Contains(SearchString) ||
                //    m.Color.Contains(SearchString) ||
                //    m.BasePrice.ToString().Contains(SearchString) ||
                //    m.FunctionKilometers.ToString().Contains(SearchString) ||
                //    categories.Where(a => a.Id == m.CategoryId).FirstOrDefault().Title.Contains(SearchString) ||
                //    cities.Where(city => city.Id == m.CityId).FirstOrDefault().Name.Contains(SearchString))
                //    .ToListAsync();

                //var categories = await _context.Categories.ToListAsync();
                //var cities = await _context.Cities.ToListAsync();
                //var ads = await _context.Advertisements.Where(m =>
                //    m.Title.Contains(SearchString) ||
                //    m.Color.Contains(SearchString) ||
                //    m.BasePrice.ToString().Contains(SearchString) ||
                //    m.FunctionKilometers.ToString().Contains(SearchString) ||
                //    categories.Any(a => a.Id == m.CategoryId && a.Title.Contains(SearchString)) ||
                //    cities.Any(city => city.Id == m.CityId && city.Name.Contains(SearchString))
                //).ToListAsync();

                //var allAds = await _context.Advertisements.ToListAsync();
                //var categories = await _context.Categories.ToListAsync();
                //var cities = await _context.Cities.ToListAsync();
                //var ads = allAds.Where(m =>
                //    m.Title.Contains(SearchString) ||
                //    m.Color.Contains(SearchString) ||
                //    m.BasePrice.ToString().Contains(SearchString) ||
                //    m.FunctionKilometers.ToString().Contains(SearchString) ||
                //    categories.Where(a => a.Id == m.CategoryId).FirstOrDefault().Title.Contains(SearchString) ||
                //    cities.Where(city => city.Id == m.CityId).FirstOrDefault().Name.Contains(SearchString))
                //    .ToList();

                //var allAds = await _context.Advertisements.ToListAsync();
                //var categories = await _context.Categories.ToListAsync();
                //var cities = await _context.Cities.ToListAsync();
                //var ads = allAds.Where(m =>
                //    m.Title.Contains(SearchString) ||
                //    m.Color.Contains(SearchString) ||
                //    m.BasePrice.ToString().Contains(SearchString) ||
                //    m.FunctionKilometers.ToString().Contains(SearchString) ||
                //    categories.Any(a => a.Id == m.CategoryId && a.Title.Contains(SearchString)) ||
                //    cities.Any(city => city.Id == m.CityId && city.Name.Contains(SearchString))
                //).ToList();

                var ads = await _context.Advertisements
                    .Where(m => m.Title.Contains(SearchString) ||
                    m.Color.Contains(SearchString) ||
                    m.BasePrice.ToString().Contains(SearchString) ||
                    m.FunctionKilometers.ToString().Contains(SearchString) ||
                    m.Category.Title.Contains(SearchString) ||
                    m.City.Name.Contains(SearchString))
                    .ToListAsync();


                //var ads = _context.Advertisements.Where(m => cats.Where(a => a == catsDictionary["breadcrumbs" + m.Id.ToString()]).FirstOrDefault().AsQueryable().Where(a => a.Title.ToString().Contains(SearchString)).FirstOrDefault().Title.ToString().Contains(SearchString)).ToList();
                //var avs = _context.Advertisements
                //    .Where(m =>
                //    {
                //        // ???? ???? ????????? ??????
                //         var categoriesList = cats.FirstOrDefault(a => a == catsDictionary["breadcrumbs" + m.Id.ToString()]);
                //        // ??? ????????? ???? ?? ? ????? ?? ???? SearchString ???? ????? ????
                //        var c = categoriesList.FirstOrDefault(a => a.Title.ToString().Contains(SearchString));
                //        return c.Title.Contains(SearchString);
                //    })
                //    .ToList();
                //var adv = _context.Advertisements.Where(m => cats.Where(a => a == catsDictionary["breadcrumbs" + m.Id.ToString()]).FirstOrDefault().Where(a => a.Title.ToString().Contains(SearchString)).FirstOrDefault().Title.ToString().Contains(SearchString)).ToList();
                //var ads = _context.Advertisements.Where(m => m.Title.Contains(SearchString) || m.Color.Contains(SearchString) || m.BasePrice.ToString().Contains(SearchString) || m.FunctionKilometers.ToString().Contains(SearchString) || _context.Categories.Where(a => a.Id == m.CategoryId).FirstOrDefault().Title.Contains(SearchString) || _context.Cities.Where(city => city.Id == m.CityId).FirstOrDefault().Name.Contains(SearchString) || cats.Where(a => a == catsDictionary["breadcrumbs" + m.Id.ToString()]).FirstOrDefault().AsQueryable().Where(a => a.Title.ToString().Contains(SearchString)).FirstOrDefault().Title.ToString().Contains(SearchString)).ToList();

                decimal price;
                bool isDigit = decimal.TryParse(SearchString, out price);

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

    }
}
