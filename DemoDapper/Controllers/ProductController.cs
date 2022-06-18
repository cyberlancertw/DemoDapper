using DemoDapper.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoDapper.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductFactory _factory;
        public ProductController(IFactory<Product> factory)
        {
            _factory = factory as ProductFactory;
        }

        public IActionResult List()
        {
            IEnumerable<Product> result = _factory.GetAll();
            return View(result);
        }

        public IActionResult Show(int id)
        {
            Product result = _factory.GetOne(id);
            return View(result);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product newProduct)
        {
            _factory.Create(newProduct);
            return RedirectToAction("List");
        }
    }
}
