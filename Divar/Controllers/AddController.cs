

using Divar.Db;
using Microsoft.AspNetCore.Mvc;

namespace Practise1Divar.Controllers
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
        public IActionResult AddAd(string Brand, string ItsModel, string Color, int FunctionKilometers, string ChassisAndBodyCondition, int BasePrice, string EngineCondition, string RearChassisCondition, string FrontChassisCondition, string ThirdPartyInsuranceTerm, string Gearbox, bool DoYouWantToReplace, bool IsTheChatActivated, bool IsThePhoneCallActive, string Title, string Description, string Nationality, string NationalCode)
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
            return View();
        }
    }
}
