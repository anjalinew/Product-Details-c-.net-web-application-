using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductDetails.Models;

namespace ProductDetails.Controllers
{
    public class OrderController : Controller
    {
        private readonly ProductsContext _dbContext;

        public OrderController(ProductsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var orders = _dbContext.Orders.Where(o => !o.IsProcessed).ToList();
            return View(orders);
        }

        public IActionResult Process(int id)
        {
            var order = _dbContext.Orders.Find(id);
            order.IsProcessed = true;
            _dbContext.SaveChanges();
            return View("Process");
        }
    }
}
