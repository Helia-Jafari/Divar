

using Divar.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
public IActionResult Index(Tuple<Advertisement, List<Category>> myTuple)
{
            myTuple.Item1.Title= "Active";
            myTuple.Item1.InsertDate = DateTime.Now;
            myTuple.Item1.UpdateDate = DateTime.Now;
            if (!ModelState.IsValid)
            {
                Tuple<Advertisement, List<Category>> tuplee = new Tuple<Advertisement, List<Category>>(new Advertisement(), categories);
                return View(tuplee);
            }
            var myModel = new Advertisement()
    {
                //CategoryId = model.CategoryId,
        Brand = myTuple.Item1.Brand,
        ItsModel = myTuple.Item1.ItsModel,
        Color = myTuple.Item1.Color,
        FunctionKilometers = Convert.ToInt32(myTuple.Item1.FunctionKilometers),
        ChassisAndBodyCondition = myTuple.Item1.ChassisAndBodyCondition,
        BasePrice = Convert.ToInt32(myTuple.Item1.BasePrice),
        EngineCondition = myTuple.Item1.EngineCondition,
        RearChassisCondition = myTuple.Item1.RearChassisCondition,
        FrontChassisCondition = myTuple.Item1.FrontChassisCondition,
        ThirdPartyInsuranceTerm = myTuple.Item1.ThirdPartyInsuranceTerm,
        Gearbox = myTuple.Item1.Gearbox,
        DoYouWantToReplace = myTuple.Item1.DoYouWantToReplace,
        IsTheChatActivated =    myTuple.Item1.IsTheChatActivated,
                IsThePhoneCallActive = myTuple.Item1.IsThePhoneCallActive,
                Title = myTuple.Item1.Title,
        Description = myTuple.Item1.Description,
        Nationality = myTuple.Item1.Nationality,
        NationalCode = myTuple.Item1.NationalCode,
        Status = myTuple.Item1.Status,
        InsertDate = myTuple.Item1.InsertDate,
        UpdateDate = myTuple.Item1.UpdateDate
    };
    _context.Advertisements.Add(myModel);
    _context.SaveChanges();
            Tuple<Advertisement, List<Category>> tuple = new Tuple<Advertisement, List<Category>>(new Advertisement(), categories);
            return View(tuple);
        }
    }
}
