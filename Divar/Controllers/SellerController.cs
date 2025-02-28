using Divar.Db;
using Divar.Interfaces;
using Divar.Services;
using Divar.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Divar.Controllers
{
    public class SellerController : Controller
    {
        private readonly ILogger<SellerController> _logger;
        private readonly DivarContext _context;
        //private readonly IStringLocalizer<HomeController> _localizer;
        //private readonly ILocalizationService _localizationService;

        private readonly ISellercService _sellercsService;
        public SellerController(ILogger<SellerController> logger, DivarContext db, IStringLocalizer<HomeController> localizer, ISellercService sellercsService)
        {
            _context = db;
            _logger = logger;
            //_localizer = localizer;
            _sellercsService = sellercsService;
            //_localizationService = localizationService;
            //categories = _context.Categories.ToList<Category>();

            //_advertisementMapper = advertisementMapper;
        }

        public async Task<IActionResult> Index()
        {
            var Viesws = await _sellercsService.GetAllSellersAsyncSellerVM();

            return View("Index", Viesws);


        }
        [HttpPost]
        public async Task<IActionResult> Index(string SearchString)
        {
            var memberList = await _sellercsService.GetAllSellersAsyncSellerVM();
            if (!ModelState.IsValid)
            {
                return View("Index", memberList);
            }
            if (!SearchString.IsNullOrEmpty())
            {
                var ads = await _sellercsService.SearchSellersAsync(SearchString);
                return View("Index", ads);
            }
            return View("Index", memberList);
        }
        public async Task<IActionResult> SignUp()
        {
            return View("../Seller/SignUp");
        }
        public async Task<IActionResult> LogIn()
        {
            return View("../Seller/LogIn");
        }


        //[HttpPost("ads/add")]
        //[HttpPost("advertisements/add")]
        //[HttpPost("items/add")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SellerSignUpViewModel model)
        {
            var Viesws = await _sellercsService.GetAllSellersAsyncSellerVM();
            if (!ModelState.IsValid)
            {
                //Tuple<Advertisement, List<Category>> tuplee = new Tuple<Advertisement, List<Category>>(new Advertisement(), categories);
                return View("../Seller/Index", Viesws);
            }
            ;
            //Tuple<Advertisement, List<Category>> tuple = new Tuple<Advertisement, List<Category>>(new Advertisement(), categories);



            await _sellercsService.AddSellerAsync(model);

            return View("../Seller/Index", Viesws);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(SellerLogInViewModel model)
        {
                var Viesws = await _sellercsService.GetAllSellersAsyncSellerVM();
                if (!ModelState.IsValid)
            {
                //Tuple<Advertisement, List<Category>> tuplee = new Tuple<Advertisement, List<Category>>(new Advertisement(), categories);
                return View("../Seller/Index", Viesws);
            }
            ;
            //Tuple<Advertisement, List<Category>> tuple = new Tuple<Advertisement, List<Category>>(new Advertisement(), categories);



            await _sellercsService.LogInSellerAsync(model.NationalCode);

            return View("../Seller/Index", Viesws);
        }
        public async Task<IActionResult> Details(int id)
        {

            var seller = await _sellercsService.GetSellerByIdAsyncSellerDetailsVM(id);
            if (seller == null)
            {
                return NotFound("محصولی با این شناسه یافت نشد.");
            }

            return View(seller);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _sellercsService.DeleteSellerAsync(id);
            var Viesws = await _sellercsService.GetAllSellersAsyncSellerVM();
            return View("../Seller/Index", Viesws);
        }

        public async Task<IActionResult> Edit(int id)
        {

            var view = await _sellercsService.GetSellerByIdAsyncSellerEditVM(id);
            if (view == null) return NotFound();
            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SellerEditViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View("Details");
            };

            await _sellercsService.UpdateSellerAsync(model);
            var view = await _sellercsService.GetSellerByIdAsyncSellerDetailsVM(model.Id);


            return View("Details", view);

        }
    }
}
