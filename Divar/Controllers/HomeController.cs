using Divar.Db;
using Divar.Models;
using Microsoft.AspNetCore.Mvc;
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

        private readonly DivarContext _db;
        public HomeController(DivarContext db)
        {

            _db = db;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult AddAd(string Category, string City, string Brand, string Model, string Color, string FunctionKilometers, string ChassisAndBodyCondition, string BasePrice, string EngineCondition, string RearChassisCondition, string FrontChassisCondition, string ThirdPartyInsuranceTerm, string Gearbox, string DoYouWantToReplace, string IsTheChatActivated, string IsThePhoneCallActive, string Title, string Description)
        {
            if (!ModelState.IsValid) { return View(); }

            var model = new Advertisement()
            {
                City=City,
                Brand= Brand,
                Model= Model,
                Color= Color,
                FunctionKilometers= FunctionKilometers,
                ChassisAndBodyCondition= ChassisAndBodyCondition,
                BasePrice= BasePrice,
                EngineCondition= EngineCondition,
                RearChassisCondition= RearChassisCondition,
                FrontChassisCondition= FrontChassisCondition,
                ThirdPartyInsuranceTerm= ThirdPartyInsuranceTerm,
                Gearbox= Gearbox,
                DoYouWantToReplace= DoYouWantToReplace,
                IsTheChatActivated= IsTheChatActivated,
                IsThePhoneCallActive= IsThePhoneCallActive,
                Title= Title,
                Description= Description
            };
            //{
            //    BasePrice = advertisement.BasePrice
            //};
            _db.Advertisements.Add(model);

            _db.SaveChanges();
            return View();

        }
    }
}
