using Divar.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Localization;
using System;
using System.Globalization;

namespace Divar.Controllers
{
    public class AddController : Controller
    {
        private readonly DivarContext _context;
        private readonly IStringLocalizer<AddController> _localizer;
        public List<Category> categories;
        //public List<City> cities;

        public AddController(DivarContext db, IStringLocalizer<AddController> localizer)
        {
            _context = db;
            _localizer = localizer;
            //cities = _context.Cities.ToList();
            categories=_context.Categories.ToList<Category>();
        }
        public IActionResult Index()
        {

            //var tuple = new Tuple<Advertisement, DivarContext>(new Advertisement(),new DivarContext());
            //return View(tuple);
            //Tuple<Advertisement, List<Category>> tuple = new Tuple<Advertisement, List<Category>>(new Advertisement(), categories);


            //List<Category> categories = new List<Category>();
            //foreach (var item in _context.Categories.ToList<Category>())
            //{
            //    categories.Add(item);
            //}
            //ViewData["categories"] = categories;

            //List<Category> cs = new List<Category>();
            //foreach (var item in categories)
            //{
            //    cs.Add(item);
            //}

            //ViewData["categories"] = cs;

            List<Category> cs = new List<Category>();
            foreach (var item in categories)
            {
                cs.Add(item);
            }

            ViewData["categories"] = cs;

            ViewData["BasePriceAddViewData"] = _localizer["BasePriceAdd"];
            ViewData["BrandAddViewData"] = _localizer["BrandAdd"];
            ViewData["CategoryIdAddViewData"] = _localizer["CategoryIdAdd"];
            ViewData["ChassisAndBodyConditionAddViewData"] = _localizer["ChassisAndBodyConditionAdd"];
            ViewData["CityIdAddViewData"] = _localizer["CityIdAdd"];
            ViewData["ColorAddViewData"] = _localizer["ColorAdd"];
            ViewData["DescriptionAddViewData"] = _localizer["DescriptionAdd"];
            ViewData["DoYouWantToReplaceAddViewData"] = _localizer["DoYouWantToReplaceAdd"];
            ViewData["EngineConditionAddViewData"] = _localizer["EngineConditionAdd"];
            ViewData["FrontChassisConditionAddViewData"] = _localizer["FrontChassisConditionAdd"];
            ViewData["FunctionKilometersAddViewData"] = _localizer["FunctionKilometersAdd"];
            ViewData["GearboxAddViewData"] = _localizer["GearboxAdd"];
            ViewData["IsTheChatActivatedAddViewData"] = _localizer["IsTheChatActivatedAdd"];
            ViewData["IsThePhoneCallActiveAddViewData"] = _localizer["IsThePhoneCallActiveAdd"];
            ViewData["ItsModelAddViewData"] = _localizer["ItsModelAdd"];
            ViewData["NationalCodeAddViewData"] = _localizer["NationalCodeAdd"];
            ViewData["NationalityAddViewData"] = _localizer["NationalityAdd"];
            ViewData["RearChassisConditionAddViewData"] = _localizer["RearChassisConditionAdd"];
            ViewData["ThirdPartyInsuranceTermAddViewData"] = _localizer["ThirdPartyInsuranceTermAdd"];
            ViewData["TitleAddViewData"] = _localizer["TitleAdd"];
            ViewData["SubmitAddViewData"] = _localizer["SubmitAdd"];
            ViewData["RequiredInputErrorAddViewData"] = _localizer["RequiredInputError"];
            ViewData["HomeMenueLayouteViewData"] = _localizer["HomeMenueLayoute"];
            ViewData["AddAdMenueLayouteViewData"] = _localizer["AddAdMenueLayoute"];
            //switch (CultureInfo.CurrentCulture.ToString())
            //{
            //    case "en-US":
            //        ViewData["dir"] = "ltr";
            //        break;
            //    case "fa-IR":
            //        ViewData["dir"] = "rlt";
            //        break;
            //}
            if (CultureInfo.CurrentCulture.ToString() == "fa-IR")
            {
                ViewData["dir"] = "rlt";
            }
            else
            {
                ViewData["dir"] = "ltr";
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
public IActionResult Index(Advertisement model)
        {
            List<Category> cs = new List<Category>();
            foreach (var item in categories)
            {
                cs.Add(item);
            }

            ViewData["categories"] = cs;

            ViewData["BasePriceAddViewData"] = _localizer["BasePriceAdd"];
            ViewData["BrandAddViewData"] = _localizer["BrandAdd"];
            ViewData["CategoryIdAddViewData"] = _localizer["CategoryIdAdd"];
            ViewData["ChassisAndBodyConditionAddViewData"] = _localizer["ChassisAndBodyConditionAdd"];
            ViewData["CityIdAddViewData"] = _localizer["CityIdAdd"];
            ViewData["ColorAddViewData"] = _localizer["ColorAdd"];
            ViewData["DescriptionAddViewData"] = _localizer["DescriptionAdd"];
            ViewData["DoYouWantToReplaceAddViewData"] = _localizer["DoYouWantToReplaceAdd"];
            ViewData["EngineConditionAddViewData"] = _localizer["EngineConditionAdd"];
            ViewData["FrontChassisConditionAddViewData"] = _localizer["FrontChassisConditionAdd"];
            ViewData["FunctionKilometersAddViewData"] = _localizer["FunctionKilometersAdd"];
            ViewData["GearboxAddViewData"] = _localizer["GearboxAdd"];
            ViewData["IsTheChatActivatedAddViewData"] = _localizer["IsTheChatActivatedAdd"];
            ViewData["IsThePhoneCallActiveAddViewData"] = _localizer["IsThePhoneCallActiveAdd"];
            ViewData["ItsModelAddViewData"] = _localizer["ItsModelAdd"];
            ViewData["NationalCodeAddViewData"] = _localizer["NationalCodeAdd"];
            ViewData["NationalityAddViewData"] = _localizer["NationalityAdd"];
            ViewData["RearChassisConditionAddViewData"] = _localizer["RearChassisConditionAdd"];
            ViewData["ThirdPartyInsuranceTermAddViewData"] = _localizer["ThirdPartyInsuranceTermAdd"];
            ViewData["TitleAddViewData"] = _localizer["TitleAdd"];
            ViewData["SubmitAddViewData"] = _localizer["SubmitAdd"];
            ViewData["RequiredInputErrorAddViewData"] = _localizer["RequiredInputErrorAdd"];
            //ViewData["HomeMenueLayouteViewData"] = _localizer["HomeMenueLayoute"];
            //ViewData["AddAdMenueLayouteViewData"] = _localizer["AddAdMenueLayoute"];
            //switch (CultureInfo.CurrentCulture.ToString())
            //{
            //    case "en-US":
            //        ViewData["dir"] = "ltr";
            //        break;
            //    case "fa-IR":
            //        ViewData["dir"] = "rlt";
            //        break;
            //}
            if (CultureInfo.CurrentCulture.ToString() == "fa-IR")
            {
                ViewData["dir"] = "rlt";
            }
            else
            {
                ViewData["dir"] = "ltr";
            }



            model.Status = "Active";
            model.InsertDate = DateTime.Now;
            model.UpdateDate = DateTime.Now;
            //model.Category = _context.Categories.Where(cat => cat.Id == model.CategoryId).FirstOrDefault();
            if (!ModelState.IsValid)
            {
                //Tuple<Advertisement, List<Category>> tuplee = new Tuple<Advertisement, List<Category>>(new Advertisement(), categories);
                return View();
            };
            var myModel = new Advertisement()
            {
                CategoryId = model.CategoryId,
                CityId = model.CityId,
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
                UpdateDate = model.UpdateDate,
                //Category =
                //{
                //    Title =model.Category.Title,
                //    Description=model.Category.Description,
                //    Status=model.Category.Status,
                //    Icon=model.Category.Icon,
                //    ParentId=model.Category.ParentId,
                //    Advertisements = model.Category.Advertisements
                //},
                //AdvertisementImages = model.AdvertisementImages,
                //City = model.City,
                //Latitude = model.Latitude,
                //Longitude = model.Longitude,
            };
    _context.Advertisements.Add(myModel);
    _context.SaveChanges();
            //Tuple<Advertisement, List<Category>> tuple = new Tuple<Advertisement, List<Category>>(new Advertisement(), categories);
            return View();
        }
    }
}
