

using Divar.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace Divar.Controllers
{
    public class AddController : Controller
    {
        private readonly DivarContext _context;
        public List<Category> categories;
        //public List<City> cities;

        public AddController(DivarContext db)
        {
            _context = db;
            categories = _context.Categories.ToList();
            //cities = _context.Cities.ToList();
        }
        public IActionResult Index()
        {

            //var tuple = new Tuple<Advertisement, DivarContext>(new Advertisement(),new DivarContext());
            //return View(tuple);
            Tuple<Advertisement, List<Category>> tuple = new Tuple<Advertisement, List<Category>>(new Advertisement(), categories);
            return View(tuple);
        }


        [HttpPost]
public IActionResult Index(Advertisement model)
{
            model.Status = "Active";
            model.InsertDate = DateTime.Now;
            model.UpdateDate = DateTime.Now;
            if (!ModelState.IsValid)
            {
                Tuple<Advertisement, List<Category>> tuplee = new Tuple<Advertisement, List<Category>>(new Advertisement(), categories);
                return View(tuplee);
            }
            var myModel = new Advertisement()
    {
                CategoryId = model.CategoryId,
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
        DoYouWantToReplace = model.DoYouWantToReplace,
        IsTheChatActivated = model.IsTheChatActivated,
                IsThePhoneCallActive = model.IsThePhoneCallActive,
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
            Tuple<Advertisement, List<Category>> tuple = new Tuple<Advertisement, List<Category>>(new Advertisement(), categories);
            return View(tuple);
        }
    }
}
