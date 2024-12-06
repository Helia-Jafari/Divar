
using Divar.Db;
using Divar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Divar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DivarContext _context;
        private readonly IStringLocalizer<HomeController> _localizer;


        public HomeController(ILogger<HomeController> logger, DivarContext db, IStringLocalizer<HomeController> localizer)
        {
            _context = db;
            _logger = logger;
            _localizer = localizer;
        }

        public IActionResult Index()
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
            ViewData["TitleHomeViewData"] = _localizer["AdvertisementTitle"];
            ViewData["ColorHomeViewData"] = _localizer["AdvertisementColor"];
            ViewData["BasePriceHomeViewData"] = _localizer["AdvertisementBasePrice"];
            ViewData["FunctionKilometersHomeViewData"] = _localizer["AdvertisementFunctionKilometers"];
            ViewData["CityHomeViewData"] = _localizer["AdvertisementCity"];
            ViewData["categories"] = _context.Categories.ToList<Category>();
            var Viesws = _context.Advertisements.ToList();

            foreach (var ad in Viesws)
            {
                Category c = _context.Categories.Where(c => c.Id == ad.CategoryId).FirstOrDefault();
                List<Category> breadcrumbs = new List<Category>();
                breadcrumbs.Add(c);
                while (c.ParentId != null){
                    Category parent = _context.Categories.Where(cat => cat.Id == c.ParentId).FirstOrDefault();
                    breadcrumbs.Add(parent);
                    c = parent;
                }
                ViewData["breadcrumbs"+ad.Id.ToString()] = breadcrumbs;

                ViewData["city" + ad.Id.ToString()] = _context.Cities.Where(cat => cat.Id == ad.CityId).FirstOrDefault().Name;
            }



            return View(Viesws);


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
        [HttpPost]
        public IActionResult HomeSearch(string SearchString)
        {

            ViewData["SucceededSearch"] = _localizer["SucceededSearch"];
            ViewData["TitleHomeViewData"] = _localizer["AdvertisementTitle"];
            ViewData["ColorHomeViewData"] = _localizer["AdvertisementColor"];
            ViewData["BasePriceHomeViewData"] = _localizer["AdvertisementBasePrice"];
            ViewData["FunctionKilometersHomeViewData"] = _localizer["AdvertisementFunctionKilometers"];
            ViewData["CityHomeViewData"] = _localizer["AdvertisementCity"];

            var memberList = _context.Advertisements.ToList();
            foreach (var ad in memberList)
            {
                Category c = _context.Categories.Where(c => c.Id == ad.CategoryId).FirstOrDefault();
                List<Category> breadcrumbs = new List<Category>();
                breadcrumbs.Add(c);
                while (c.ParentId != null)
                {
                    Category parent = _context.Categories.Where(cat => cat.Id == c.ParentId).FirstOrDefault();
                    breadcrumbs.Add(parent);
                    c = parent;
                }
                ViewData["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;

                ViewData["city" + ad.Id.ToString()] = _context.Cities.Where(cat => cat.Id == ad.CityId).FirstOrDefault().Name;
            }

            if (!ModelState.IsValid)
            {
                return View("Index", memberList);
            }
            if (!SearchString.IsNullOrEmpty())
            {
                //var category = _context.Advertisements.Where(ad => ad.Category.Title.Contains(SearchString)).ToList();
                //if (!category.IsNullOrEmpty())
                //{
                //    var adss = _context.Advertisements.ToList().Where(m => m.Title.Contains(SearchString) || m.Color.Contains(SearchString) || m.BasePrice.ToString().Contains(SearchString) || m.FunctionKilometers.ToString().Contains(SearchString) || m.Category.Title.Contains(SearchString)).ToList();
                //    return View("Index", adss);
                //}

                SearchString = SearchString.Trim();
                //List<Advertisement> ads = _context.Advertisements.ToList().Where(m => m.Title.Contains(SearchString) || m.Color.Contains(SearchString) || m.BasePrice.ToString().Contains(SearchString) || m.FunctionKilometers.ToString().Contains(SearchString)|| _context.Categories.Where(cat=>cat.Id==m.CategoryId).FirstOrDefault().Title.Contains(SearchString) || _context.Cities.Where(city => city.Id == m.CityId).FirstOrDefault().Name.Contains(SearchString)).ToList();
                decimal price;
                bool isDigit = decimal.TryParse(SearchString, out price);
                List<Advertisement> ads = _context.Advertisements.ToList().Where(m => m.Title.Contains(SearchString) || m.Color.Contains(SearchString) || (isDigit && m.BasePrice>=price-1000000 && m.BasePrice<=price+1000000) || m.FunctionKilometers.ToString().Contains(SearchString) || m.City.Name.Contains(SearchString) || m.Category.Title.Contains(SearchString)).ToList();
                //foreach (var item in _context.Advertisements.ToList())
                //{
                //    List<Category> cats = ViewData["breadcrumbs" + item.Id.ToString()];
                //}
                //var ads = _context.Advertisements.ToList().Where(m => m.Title.Contains(SearchString) || m.Color.Contains(SearchString) || m.BasePrice.ToString().Contains(SearchString) || m.FunctionKilometers.ToString().Contains(SearchString) || ViewData["breadcrumbs" + m.Id.ToString()] || _context.Cities.Where(city => city.Id == m.CityId).FirstOrDefault().Name.Contains(SearchString)).ToList();
                //var ads = _context.Advertisements.ToList().Where(m => m.Title.Contains(SearchString) || m.Color.Contains(SearchString) || m.BasePrice.ToString().Contains(SearchString) || m.FunctionKilometers.ToString().Contains(SearchString)|| _context.Categories.Where(cat=>cat.Id==m.CategoryId).ToList().ToString().Contains(SearchString) || _context.Cities.Where(city => city.Id == m.CityId).FirstOrDefault().Name.Contains(SearchString)).ToList();

                foreach (var ad in ads)
                {
                    Category c = _context.Categories.Where(c => c.Id == ad.CategoryId).FirstOrDefault();
                    List<Category> breadcrumbs = new List<Category>();
                    breadcrumbs.Add(c);
                    while (c.ParentId != null)
                    {
                        Category parent = _context.Categories.Where(cat => cat.Id == c.ParentId).FirstOrDefault();
                        breadcrumbs.Add(parent);
                        c = parent;
                    }
                    ViewData["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;

                    ViewData["city" + ad.Id.ToString()] = _context.Cities.Where(cat => cat.Id == ad.CityId).FirstOrDefault().Name;
                }

                return View("Index", ads);
            }

            foreach (var ad in memberList)
            {
                Category c = _context.Categories.Where(c => c.Id == ad.CategoryId).FirstOrDefault();
                List<Category> breadcrumbs = new List<Category>();
                breadcrumbs.Add(c);
                while (c.ParentId != null)
                {
                    Category parent = _context.Categories.Where(cat => cat.Id == c.ParentId).FirstOrDefault();
                    breadcrumbs.Add(parent);
                    c = parent;
                }
                ViewData["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;

                ViewData["city" + ad.Id.ToString()] = _context.Cities.Where(cat => cat.Id == ad.CityId).FirstOrDefault().Name;
            }

            return View("Index", memberList);

        }

    }
}
