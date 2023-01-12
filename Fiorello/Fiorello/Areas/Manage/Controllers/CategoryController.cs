using Fiorello.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CategoryController : Controller
    {
        private readonly FiorelloContext _fiorelloContext;

        public CategoryController(FiorelloContext fiorelloContext)
        {
            _fiorelloContext = fiorelloContext;
        }


        public IActionResult Index()
        {
            return View(_fiorelloContext.categories.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            

            _fiorelloContext.categories.Add(category);
            _fiorelloContext.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Update(int id)
        {
            Category category = _fiorelloContext.categories.Find(id);

            if (category == null) return View("Error");
            return View();
        }
        [HttpPost]
        public IActionResult Update(int id, Category category)
        {
            if (category == null) return View("Error");

            Category existCategory = _fiorelloContext.categories.FirstOrDefault(x => x.Id == id);

            existCategory.Name=category.Name;

            _fiorelloContext.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            return View("Index");
        }
        public IActionResult Delete(int id,Category category)
        {
            return View("Index");
        }
    }
}
