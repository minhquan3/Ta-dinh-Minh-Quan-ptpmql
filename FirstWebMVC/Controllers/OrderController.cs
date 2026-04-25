using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Data;
using FirstWebMVC.ViewModels;
using FirstWebMVC.Models; // nhớ import Models để dùng Order
using System.Linq;

namespace FirstWebMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Order
        public IActionResult Index()
        {
            var orders = _context.Orders.ToList();
            return View(orders);
        }

        // Action xem chi tiết đơn hàng của một khách hàng
        public IActionResult Details(int customerId)
        {
            var data = from o in _context.Orders
                       join od in _context.OrderDetails on o.OrderID equals od.OrderID
                       join p in _context.Products on od.ProductID equals p.ProductID
                       join c in _context.Customers on o.CustomerID equals c.CustomerID
                       where c.CustomerID == customerId
                       select new OrderDetailViewModel
                       {
                           CustomerName = c.CustomerName,
                           OrderDate = o.OrderDate,
                           ProductName = p.ProductName,
                           Quantity = od.Quantity,
                           Price = p.Price
                       };

            return View(data.ToList());
        }
    }
}
