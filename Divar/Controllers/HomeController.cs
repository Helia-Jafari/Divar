
using Divar.Db;
using Divar.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            foreach (var item in _context.Advertisements.ToList())
            {
                var view = new ViwShowAdvertisement
                {
                    Title=item.Title,
                    BasePrice=item.BasePrice,
                    FunctionKilometers=item.FunctionKilometers
                };
                _context.ViwShowAdvertisements.Add(view);
            }
            var Viesws = _context.ViwShowAdvertisements.ToList();
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

    }
}
