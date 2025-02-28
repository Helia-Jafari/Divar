using Divar.Db;
using Divar.Interfaces;
using Divar.Mapper;
using Divar.Services;
using Divar.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Localization;
using System;
using System.Globalization;
using System.Text.Json;

namespace Divar.Controllers
{
    
    public class AddController : Controller
    {
        private readonly DivarContext _context;
        private readonly IStringLocalizer<AddController> _localizer;
        private readonly ILocalizationService _localizationService;
        private readonly IAdvertisementService _advertisementService;
        public List<Category> categories;
        private readonly ICityService _cityService;
        private readonly ICategoryService _categoryService;

        List<List<Category>> cats = new List<List<Category>>();
        Dictionary<string, List<Category>> catsDictionary = new Dictionary<string, List<Category>>();
        //public List<City> cities;

        //private readonly AdvertisementMapper _advertisementMapper;

        public AddController(DivarContext db, IStringLocalizer<AddController> localizer, ICityService cityService, ICategoryService categoryService, IAdvertisementService advertisementService, ILocalizationService localizationService)
        {
            _context = db;
            _localizer = localizer;
            _advertisementService = advertisementService;
            _localizationService = localizationService;
            _cityService = cityService;
            _categoryService = categoryService;
            //cities = _context.Cities.ToList();

            //_advertisementMapper = advertisementMapper;
        }
        //[HttpGet("ads/add")]
        //[HttpGet("advertisements/add")]
        //[HttpGet("items/add")]
        [HttpGet("add")]
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

            //ViewData["BasePriceAddViewData"] = _localizer["BasePriceAdd"];
            //ViewData["BrandAddViewData"] = _localizer["BrandAdd"];
            //ViewData["CategoryIdAddViewData"] = _localizer["CategoryIdAdd"];
            //ViewData["ChassisAndBodyConditionAddViewData"] = _localizer["ChassisAndBodyConditionAdd"];
            //ViewData["CityIdAddViewData"] = _localizer["CityIdAdd"];
            //ViewData["ColorAddViewData"] = _localizer["ColorAdd"];
            //ViewData["DescriptionAddViewData"] = _localizer["DescriptionAdd"];
            //ViewData["DoYouWantToReplaceAddViewData"] = _localizer["DoYouWantToReplaceAdd"];
            //ViewData["EngineConditionAddViewData"] = _localizer["EngineConditionAdd"];
            //ViewData["FrontChassisConditionAddViewData"] = _localizer["FrontChassisConditionAdd"];
            //ViewData["FunctionKilometersAddViewData"] = _localizer["FunctionKilometersAdd"];
            //ViewData["GearboxAddViewData"] = _localizer["GearboxAdd"];
            //ViewData["IsTheChatActivatedAddViewData"] = _localizer["IsTheChatActivatedAdd"];
            //ViewData["IsThePhoneCallActiveAddViewData"] = _localizer["IsThePhoneCallActiveAdd"];
            //ViewData["ItsModelAddViewData"] = _localizer["ItsModelAdd"];
            //ViewData["NationalCodeAddViewData"] = _localizer["NationalCodeAdd"];
            //ViewData["NationalityAddViewData"] = _localizer["NationalityAdd"];
            //ViewData["RearChassisConditionAddViewData"] = _localizer["RearChassisConditionAdd"];
            //ViewData["ThirdPartyInsuranceTermAddViewData"] = _localizer["ThirdPartyInsuranceTermAdd"];
            //ViewData["TitleAddViewData"] = _localizer["TitleAdd"];
            //ViewData["SubmitAddViewData"] = _localizer["SubmitAdd"];
            //ViewData["RequiredInputErrorAddViewData"] = _localizer["RequiredInputError"];
            //ViewData["HomeMenueLayouteViewData"] = _localizer["HomeMenueLayoute"];
            //ViewData["AddAdMenueLayouteViewData"] = _localizer["AddAdMenueLayoute"];

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


        //[HttpPost("ads/add")]
        //[HttpPost("advertisements/add")]
        //[HttpPost("items/add")]
        [HttpPost("add")]
        [ValidateAntiForgeryToken]
public async Task<IActionResult> Index(AddViewModel model)
        {
            categories = await _context.Categories.ToListAsync<Category>();
            List<Category> cs = new List<Category>();
            foreach (var item in categories)
            {
                cs.Add(item);
            }

            ViewData["categories"] = cs;

            //ViewData["BasePriceAddViewData"] = _localizer["BasePriceAdd"];
            //ViewData["BrandAddViewData"] = _localizer["BrandAdd"];
            //ViewData["CategoryIdAddViewData"] = _localizer["CategoryIdAdd"];
            //ViewData["ChassisAndBodyConditionAddViewData"] = _localizer["ChassisAndBodyConditionAdd"];
            //ViewData["CityIdAddViewData"] = _localizer["CityIdAdd"];
            //ViewData["ColorAddViewData"] = _localizer["ColorAdd"];
            //ViewData["DescriptionAddViewData"] = _localizer["DescriptionAdd"];
            //ViewData["DoYouWantToReplaceAddViewData"] = _localizer["DoYouWantToReplaceAdd"];
            //ViewData["EngineConditionAddViewData"] = _localizer["EngineConditionAdd"];
            //ViewData["FrontChassisConditionAddViewData"] = _localizer["FrontChassisConditionAdd"];
            //ViewData["FunctionKilometersAddViewData"] = _localizer["FunctionKilometersAdd"];
            //ViewData["GearboxAddViewData"] = _localizer["GearboxAdd"];
            //ViewData["IsTheChatActivatedAddViewData"] = _localizer["IsTheChatActivatedAdd"];
            //ViewData["IsThePhoneCallActiveAddViewData"] = _localizer["IsThePhoneCallActiveAdd"];
            //ViewData["ItsModelAddViewData"] = _localizer["ItsModelAdd"];
            //ViewData["NationalCodeAddViewData"] = _localizer["NationalCodeAdd"];
            //ViewData["NationalityAddViewData"] = _localizer["NationalityAdd"];
            //ViewData["RearChassisConditionAddViewData"] = _localizer["RearChassisConditionAdd"];
            //ViewData["ThirdPartyInsuranceTermAddViewData"] = _localizer["ThirdPartyInsuranceTermAdd"];
            //ViewData["TitleAddViewData"] = _localizer["TitleAdd"];
            //ViewData["SubmitAddViewData"] = _localizer["SubmitAdd"];
            //ViewData["RequiredInputErrorAddViewData"] = _localizer["RequiredInputErrorAdd"];
            string sellll = HttpContext.Request.Cookies["sellerId"];
            if (sellll != null)
            {
                int sel = JsonSerializer.Deserialize<int>(sellll);
                var seller = _context.Sellers.Where(x => x.Id == sel).FirstOrDefault();
                if (seller != null)
                {
                    ViewData["sellerfirstname"] = seller.FirstName + " عزیز خوش آمدی ";


                }


            }
            else
            {

                ViewData["sellerfirstname"] = "ثبت نام نکرده اید";
            }




            var Viesws = await _advertisementService.GetAllAdvertisementsAsyncHomeVM();
            foreach (var ad in Viesws)
            {
                var breadcrumbs = await _categoryService.GetBreadcrumbsAsync((int)ad.CategoryId);

                ViewData["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;
                catsDictionary["breadcrumbs" + ad.Id.ToString()] = breadcrumbs;
                this.cats.Add(breadcrumbs);

                var city = await _cityService.GetCityByIdAsync((int)ad.CityId);
                ViewData["city" + ad.Id.ToString()] = city.Name;
            }


            if (!ModelState.IsValid)
            {
                //Tuple<Advertisement, List<Category>> tuplee = new Tuple<Advertisement, List<Category>>(new Advertisement(), categories);
                return View("../Home/Index",Viesws);
            };
            //Tuple<Advertisement, List<Category>> tuple = new Tuple<Advertisement, List<Category>>(new Advertisement(), categories);



            await _advertisementService.AddAdvertisementAsync(model);

            return View("../Home/Index", Viesws);
        }


        public async Task<IActionResult> ChangeCulture(string culture)
        {

            //categories = await _context.Categories.ToListAsync<Category>();
            //List<Category> cs = new List<Category>();
            //foreach (var item in categories)
            //{
            //    cs.Add(item);
            //}

            //ViewData["categories"] = cs;

            //ViewData["BasePriceAddViewData"] = _localizer["BasePriceAdd"];
            //ViewData["BrandAddViewData"] = _localizer["BrandAdd"];
            //ViewData["CategoryIdAddViewData"] = _localizer["CategoryIdAdd"];
            //ViewData["ChassisAndBodyConditionAddViewData"] = _localizer["ChassisAndBodyConditionAdd"];
            //ViewData["CityIdAddViewData"] = _localizer["CityIdAdd"];
            //ViewData["ColorAddViewData"] = _localizer["ColorAdd"];
            //ViewData["DescriptionAddViewData"] = _localizer["DescriptionAdd"];
            //ViewData["DoYouWantToReplaceAddViewData"] = _localizer["DoYouWantToReplaceAdd"];
            //ViewData["EngineConditionAddViewData"] = _localizer["EngineConditionAdd"];
            //ViewData["FrontChassisConditionAddViewData"] = _localizer["FrontChassisConditionAdd"];
            //ViewData["FunctionKilometersAddViewData"] = _localizer["FunctionKilometersAdd"];
            //ViewData["GearboxAddViewData"] = _localizer["GearboxAdd"];
            //ViewData["IsTheChatActivatedAddViewData"] = _localizer["IsTheChatActivatedAdd"];
            //ViewData["IsThePhoneCallActiveAddViewData"] = _localizer["IsThePhoneCallActiveAdd"];
            //ViewData["ItsModelAddViewData"] = _localizer["ItsModelAdd"];
            //ViewData["NationalCodeAddViewData"] = _localizer["NationalCodeAdd"];
            //ViewData["NationalityAddViewData"] = _localizer["NationalityAdd"];
            //ViewData["RearChassisConditionAddViewData"] = _localizer["RearChassisConditionAdd"];
            //ViewData["ThirdPartyInsuranceTermAddViewData"] = _localizer["ThirdPartyInsuranceTermAdd"];
            //ViewData["TitleAddViewData"] = _localizer["TitleAdd"];
            //ViewData["SubmitAddViewData"] = _localizer["SubmitAdd"];
            //ViewData["RequiredInputErrorAddViewData"] = _localizer["RequiredInputError"];
            //ViewData["HomeMenueLayouteViewData"] = _localizer["HomeMenueLayoute"];
            //ViewData["AddAdMenueLayouteViewData"] = _localizer["AddAdMenueLayoute"];



            _localizationService.ChangeCultureInfo(culture);



            return RedirectToAction("Index", "Add", new { culture = culture });
        }
    }
}
