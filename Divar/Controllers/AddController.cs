using Divar.Db;
using Divar.Interfaces;
using Divar.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IAdvertisementService _advertisementService;
        public List<Category> categories;
        //public List<City> cities;

        public AddController(DivarContext db, IStringLocalizer<AddController> localizer, IAdvertisementService advertisementService)
        {
            _context = db;
            _localizer = localizer;
            _advertisementService = advertisementService;
            //cities = _context.Cities.ToList();
        }
        public async Task<IActionResult> Index()
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

            categories= await _context.Categories.ToListAsync<Category>();
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
            //        ViewData["dir"] = "rtl";
            //        break;
            //}
            //if (CultureInfo.CurrentCulture.ToString() == "fa-IR")
            //{
            //    ViewData["dir"] = "rtl";
            //}
            //else
            //{
            //    ViewData["dir"] = "ltr";
            //}

            return View("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
public async Task<IActionResult> Index(Advertisement model)
        {
            categories = await _context.Categories.ToListAsync<Category>();
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






            if (!ModelState.IsValid)
            {
                //Tuple<Advertisement, List<Category>> tuplee = new Tuple<Advertisement, List<Category>>(new Advertisement(), categories);
                return View("Index");
            };
            //Tuple<Advertisement, List<Category>> tuple = new Tuple<Advertisement, List<Category>>(new Advertisement(), categories);

            await _advertisementService.AddAdvertisementAsync(model);

            return View("Index");
        }


        public async Task<IActionResult> ChangeCulture(string culture)
        {

            categories = await _context.Categories.ToListAsync<Category>();
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


            //// تغییر فرهنگ به فارسی
            CultureInfo.CurrentCulture = new CultureInfo(culture);
            CultureInfo.CurrentUICulture = new CultureInfo(culture);

            // تغییر فرهنگ به فارسی
            //CultureInfo.CurrentCulture = new CultureInfo("fa-IR");
            //CultureInfo.CurrentUICulture = new CultureInfo("fa-IR");

            // هدایت به صفحه اصلی پس از تغییر فرهنگ




            return View("Index");
        }
    }
}
