using Divar.Dbs;
using Microsoft.AspNetCore.Mvc;

namespace Practise1Divar.Controllers
{
    public class AddController : Controller
    {
        private readonly DivarContext _db;
        public AddController(DivarContext db)
        {

            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult AddAd(Advertisement advertisement)
        //{
            //if (!ModelState.IsValid) { return View(); }
            //var model = new Advertisement()
            //{
            //    BasePrice = advertisement.BasePrice
            //}
            //_db.Advertisements.Add(new Advertisement
            //{

            //})
            //_db.SaveChanges();
            //return View();

        //}
    }
}
