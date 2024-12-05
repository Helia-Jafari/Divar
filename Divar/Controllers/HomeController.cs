
using Divar.Db;
using Divar.Models;
using Microsoft.AspNetCore.Mvc;
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
            ViewData["AdvertisementTitleHomeViewData"] = _localizer["AdvertisementTitle"];
            ViewData["AdvertisementColorHomeViewData"] = _localizer["AdvertisementColor"];
            ViewData["AdvertisementBasePriceHomeViewData"] = _localizer["AdvertisementBasePrice"];
            ViewData["AdvertisementFunctionKilometersHomeViewData"] = _localizer["AdvertisementFunctionKilometers"];
            var Viesws = _context.Advertisements.ToList();

            //List<Category> breadcrumbs = new List<Category>();
            //Category c=_context.Categories.Where(c=>c.Id==id)


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

            //var ads = _context.Advertisements.ToList();
            //var ads = from mem in _context.Advertisements
            //              select mem;
            if (!ModelState.IsValid)
            {
                return View();
            }
            ViewData["SucceededSearch"] = _localizer["SucceededSearch"];
            if (!SearchString.IsNullOrEmpty())
            {
                //var category = _context.Advertisements.Where(ad => ad.Category.Title.Contains(SearchString)).ToList();
                //if (!category.IsNullOrEmpty())
                //{
                //    var adss = _context.Advertisements.ToList().Where(m => m.Title.Contains(SearchString) || m.Color.Contains(SearchString) || m.BasePrice.ToString().Contains(SearchString) || m.FunctionKilometers.ToString().Contains(SearchString) || m.Category.Title.Contains(SearchString)).ToList();
                //    return View("Index", adss);
                //}
                var ads = _context.Advertisements.ToList().Where(m => m.Title.Contains(SearchString) || m.Color.Contains(SearchString) || m.BasePrice.ToString().Contains(SearchString) || m.FunctionKilometers.ToString().Contains(SearchString)||_context.Categories.Where(cat=>cat.Id==m.CategoryId).FirstOrDefault().Title.Contains(SearchString)).ToList();
                //var categories=_
                return View("Index", ads);
            }
            var memberList = _context.Advertisements.ToList();
            return View("Index", memberList);

        }

    }
}
