
using Divar.Db;
using Divar.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Divar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DivarContext _context;


        public HomeController(ILogger<HomeController> logger, DivarContext db)
        {
            _context = db;
            _logger = logger;
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
            var Viesws = _context.Advertisements.ToList();
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
            if (!String.IsNullOrEmpty(SearchString))
            {
             var ads = _context.Advertisements.ToList().Where(m => m.Title.Contains(SearchString));
             return View(ads);
            }

            var memberList = _context.Advertisements.ToList();
            return View(memberList);

        }

    }
}
