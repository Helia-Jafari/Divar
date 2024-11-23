

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
        [ValidateAntiForgeryToken]
public IActionResult Index(Advertisement model)
{
            model.Status = "Active";
            model.InsertDate = DateTime.Now;
            model.UpdateDate = DateTime.Now;
    if (!ModelState.IsValid)
            { 
                return View();
            }
            var myModel = new Advertisement()
    {
        Brand = model.Brand,
        ItsModel = model.ItsModel,
        Color = model.Color,
        FunctionKilometers = Convert.ToInt32(model.FunctionKilometers),
        ChassisAndBodyCondition = model.ChassisAndBodyCondition,
        BasePrice = Convert.ToInt32(model.BasePrice),
        EngineCondition = model.EngineCondition,
        RearChassisCondition = model.RearChassisCondition,
        FrontChassisCondition = model.FrontChassisCondition,
        ThirdPartyInsuranceTerm = model.ThirdPartyInsuranceTerm,
        Gearbox = model.Gearbox,
        //DoYouWantToReplace = model.DoYouWantToReplace,
        //IsTheChatActivated = model.IsTheChatActivated,
        //IsThePhoneCallActive = model.IsThePhoneCallActive,
        Title = model.Title,
        Description = model.Description,
        Nationality = model.Nationality,
        NationalCode = model.NationalCode,
        Status = model.Status,
        InsertDate = model.InsertDate,
        UpdateDate = model.UpdateDate
    };
    _context.Advertisements.Add(myModel);
    _context.SaveChanges();
    return View();
}
    }
}
