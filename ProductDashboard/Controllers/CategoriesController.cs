using Microsoft.AspNetCore.Mvc;
using ProductDashboard.Data;

namespace ProductDashboard.Controllers
{
    public class CategoriesController : Controller
    {
        private AppDbContext db;

        public CategoriesController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View(db.Categories);
        }
    }
}
