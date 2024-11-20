

using Divar.Db;
using Microsoft.AspNetCore.Mvc;

namespace Divar.Controllers
{
    public class AddController : Controller
    {
        private readonly DivarContext _context;
        //public readonly List<Category> categories;
        //public readonly List<City> cities;

        public AddController(DivarContext db)
        {
            _context = db;
            //categories = _context.Categories.ToList();
            //cities = _context.Cities.ToList();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAd(Advertisement model)
        {
            if (!ModelState.IsValid) { return View(); }
            var myModel = new Advertisement()
            {
                Brand = Brand,
                ItsModel = ItsModel,
                Color = Color,
                FunctionKilometers = Convert.ToInt32(FunctionKilometers),
                ChassisAndBodyCondition = ChassisAndBodyCondition,
                BasePrice = Convert.ToInt32(BasePrice),
                EngineCondition = EngineCondition,
                RearChassisCondition = RearChassisCondition,
                FrontChassisCondition = FrontChassisCondition,
                ThirdPartyInsuranceTerm = ThirdPartyInsuranceTerm,
                Gearbox = Gearbox,
                DoYouWantToReplace = DoYouWantToReplace,
                IsTheChatActivated = IsTheChatActivated,
                IsThePhoneCallActive = IsThePhoneCallActive,
                Title = Title,
                Description = Description,
                Nationality = Nationality,
                NationalCode = NationalCode,
                Status = "Active",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
            _context.Advertisements.Add(myModel);
            _context.SaveChanges();
            return View("Index");
        }
    }
}
