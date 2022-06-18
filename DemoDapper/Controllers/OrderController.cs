using DemoDapper.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoDapper.Controllers
{
    public class OrderController : Controller
    {
        private readonly IFactory<Order> _factory;

        public OrderController(IFactory<Order> factory)
        {
            _factory = factory;
        }

        public IActionResult Detail(int id)
        {
            IEnumerable<Order> result = _factory.Detail(id);
            return View(result);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
