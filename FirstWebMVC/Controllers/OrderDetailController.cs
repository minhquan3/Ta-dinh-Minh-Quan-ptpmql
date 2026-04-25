using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Data;
using FirstWebMVC.Models;
using System.Linq;

namespace FirstWebMVC.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly ApplicationDbContext _context;
        public OrderDetailController(ApplicationDbContext context) => _context = context;

        // GET: /OrderDetail
        public IActionResult Index()
        {
            var details = _context.OrderDetails.ToList();
            return View(details);
        }

        // GET: /OrderDetail/Create
        public IActionResult Create() => View();

        // POST: /OrderDetail/Create
        [HttpPost]
        public IActionResult Create(OrderDetail detail)
        {
            if (ModelState.IsValid)
            {
                _context.OrderDetails.Add(detail);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(detail);
        }

        // GET: /OrderDetail/Edit/5
        public IActionResult Edit(int id)
        {
            var detail = _context.OrderDetails.Find(id);
            return detail == null ? NotFound() : View(detail);
        }

        // POST: /OrderDetail/Edit
        [HttpPost]
        public IActionResult Edit(OrderDetail detail)
        {
            if (ModelState.IsValid)
            {
                _context.OrderDetails.Update(detail);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(detail);
        }

        // GET: /OrderDetail/Delete/5
        public IActionResult Delete(int id)
        {
            var detail = _context.OrderDetails.Find(id);
            return detail == null ? NotFound() : View(detail);
        }

        // POST: /OrderDetail/DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var detail = _context.OrderDetails.Find(id);
            if (detail != null)
            {
                _context.OrderDetails.Remove(detail);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
