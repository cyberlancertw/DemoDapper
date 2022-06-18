using DemoDapper.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoDapper.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderFactory _factory;

        public OrderController(IFactory<Order> factory)
        {
            _factory = factory as OrderFactory;
        }

        public IActionResult Detail(int id)
        {
            IEnumerable<Order> result = null;
            result = _factory.Detail(id);
            return View(result);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
