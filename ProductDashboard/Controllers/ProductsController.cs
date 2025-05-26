using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductDashboard.Data;
using ProductDashboard.Models;

namespace ProductDashboard.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext db;

        public ProductsController(AppDbContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            return View(db.Products.Include(p => p.Category));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.allCategories = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
