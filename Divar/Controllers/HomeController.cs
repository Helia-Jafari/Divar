using Divar.Models;
using Microsoft.AspNetCore.Mvc;
using Divar.Models;
using System.Diagnostics;

namespace Practise1Divar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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



        //[HttpPost]
        //public IActionResult AddAd(Advertisement advertisement)
        //{
        //if (!ModelState.IsValid) { return View(); }
        //var model = new Advertisement()
        //{
        //    BasePrice = advertisement.BasePrice
        //}
        //_db.Advertisements.Add(new Advertisement
        //{

        //})
        //_db.SaveChanges();
        //return View();

        //}
    }
}
