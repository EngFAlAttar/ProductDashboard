using Microsoft.AspNetCore.Mvc;
using ProductDashboard.Data;
using ProductDashboard.Models;

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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            db.Add(category);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var category = db.Categories.Find(id);
            if (category != null)
            {
                return View(category);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ConfirmDelete(Category category)
        {
            
            var categ = db.Categories.Find(category.CategoryId);
            if (category != null)
            {
                db.Categories.Remove(categ);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var categ = db.Categories.Find(id);
            if(categ != null)
            {
                return View(categ);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
           
                db.Categories.Update(category);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
         

        }
    }
}
