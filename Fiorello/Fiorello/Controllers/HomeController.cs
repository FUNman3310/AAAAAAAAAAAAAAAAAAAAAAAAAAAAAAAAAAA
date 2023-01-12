using Fiorello.Models;
using Fiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fiorello.Controllers
{
    public class HomeController : Controller
    {
        private readonly FiorelloContext _fiorelloContext;

        public HomeController(FiorelloContext fiorelloContext)
        {
            _fiorelloContext = fiorelloContext;
        }

        public IActionResult Index()
        {
           
           List<Product >products = _fiorelloContext.products.ToList();
            ViewBag.Category= _fiorelloContext.categories.ToList();
            ViewBag.Sliders= _fiorelloContext.sliders.ToList();
            return View(products);
        }

    }
}