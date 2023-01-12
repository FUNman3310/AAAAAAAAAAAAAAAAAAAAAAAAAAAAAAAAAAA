using Fiorello.Models;
using Fiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ProductController : Controller
    {
        private readonly FiorelloContext _fiorelloContext;
        private readonly IWebHostEnvironment _env;

        public ProductController(FiorelloContext fiorelloContext, IWebHostEnvironment env)
        {
            _fiorelloContext = fiorelloContext;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_fiorelloContext.products.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _fiorelloContext.categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreateViewModel productVM)
        {
            string name = productVM.ImageFile.FileName;
            string path = "C:\\Users\\ca.r214.16\\Desktop\\00000\\hhhhhhhhhh\\Fiorello\\Fiorello\\wwwroot\\Uploads\\Products\\" + name;

            using(FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                productVM.ImageFile.CopyTo(fileStream);
            }

            Product product = new Product
            {
                Name = productVM.Name,
                Price = productVM.Price,
                CategoryId = productVM.CategoryId,
                Image = productVM.ImageFile.FileName
            };
            productVM.Image= productVM.ImageFile.FileName;

            _fiorelloContext.products.Add(product);
            _fiorelloContext.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Update(int id)
        {
            Product product = _fiorelloContext.products.Find(id);
            ViewBag.Categories = _fiorelloContext.categories.ToList();

            if (product == null) return View("Error");
            return View();
        }
        [HttpPost]
        public IActionResult Update(int id, ProductCreateViewModel product)
        {
            ViewBag.Categories = _fiorelloContext.categories.ToList();


            Product existProduct = _fiorelloContext.products.FirstOrDefault(x => x.Id == id);
            if (existProduct == null) return View("Error");


            existProduct.Name = product.Name;
            existProduct.Price = product.Price;
            existProduct.CategoryId = product.CategoryId;
            existProduct.Image = product.Image;
        
            _fiorelloContext.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            return View("Index");
        }
        public IActionResult Delete(int id, Category category)
        {
            return View("Index");
        }
    }
}
