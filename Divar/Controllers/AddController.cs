using Divar.Dbs;
using Microsoft.AspNetCore.Mvc;
using Practise1Divar.Db;

namespace Practise1Divar.Controllers
{
    public class AddController : Controller
    {
        private readonly DivarContext _db;
        public AddController(DivarContext db)
        {

            _db = db;
        }
        [HttpPost]
        public IActionResult Index(Advertisement advertisement)
        {
            if (!ModelState.IsValid) { return View(); }
            var model = new Advertisement()
            {
                BasePrice = advertisement.BasePrice
            }
            _db.
            _db.SaveChanges();


        }
    }
}
