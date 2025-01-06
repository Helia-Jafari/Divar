
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

namespace Divar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DivarContext _context;
        private readonly IStringLocalizer<HomeController> _localizer;
        List<List<Category>> cats = new List<List<Category>>();
        Dictionary<string, List<Category>> catsDictionary = new Dictionary<string, List<Category>>();
        //catsDictionary.Add("aa", "aa");
        //catsDictionary["uuu"] = "jjj";

        //public List<Category> categories;

        public HomeController(ILogger<HomeController> logger, DivarContext db, IStringLocalizer<HomeController> localizer)
        {
            _context = db;
            _logger = logger;
            _localizer = localizer;

            //categories = _context.Categories.ToList<Category>();
        }

        public IActionResult Index()
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
            ViewData["CityHomeViewData"] = _localizer["CityHome"];
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
            //        ViewData["dir"] = "rlt";
            //        break;
            //}
            if (CultureInfo.CurrentCulture.ToString() == "fa-IR")
            {
                ViewData["dir"] = "ltr";
            } else
            {
                ViewData["dir"] = "rlt";
            }

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
                catsDictionary["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;
                this.cats.Add(breadcrumbs);

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
            ViewData["SearchHomeViewData"] = _localizer["SearchHome"];
            //switch (CultureInfo.CurrentCulture.ToString())
            //{
            //    case "en-US":
            //        ViewData["dir"] = "ltr";
            //        break;
            //    case "fa-IR":
            //        ViewData["dir"] = "rlt";
            //        break;
            //}
            if (CultureInfo.CurrentCulture.ToString() == "fa-IR")
            {
                ViewData["dir"] = "rlt";
            }
            else
            {
                ViewData["dir"] = "ltr";
            }

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
                catsDictionary["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;

                this.cats.Add(breadcrumbs);
                ViewData["city" + ad.Id.ToString()] = _context.Cities.Where(cat => cat.Id == ad.CityId).FirstOrDefault().Name;
            }


            if (!ModelState.IsValid)
            {
                return View("Index", memberList);
            }
            if (!SearchString.IsNullOrEmpty())
            {
                SearchString = SearchString.Trim();

                var ads = _context.Advertisements.Where(m => m.Title.Contains(SearchString) || m.Color.Contains(SearchString) || m.BasePrice.ToString().Contains(SearchString) || m.FunctionKilometers.ToString().Contains(SearchString) || _context.Categories.Where(a => a.Id==m.CategoryId).FirstOrDefault().Title.Contains(SearchString) || _context.Cities.Where(city => city.Id == m.CityId).FirstOrDefault().Name.Contains(SearchString)).ToList();
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
                    catsDictionary["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;

                    this.cats.Add(breadcrumbs);
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
                catsDictionary["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;

                this.cats.Add(breadcrumbs);
                ViewData["city" + ad.Id.ToString()] = _context.Cities.Where(cat => cat.Id == ad.CityId).FirstOrDefault().Name;
            }

            return View("Index", memberList);

        }

    }
}
