using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Data;
using FirstWebMVC.Models;

namespace FirstWebMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // READ: Hiển thị danh sách
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        // CREATE: GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE: POST
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // UPDATE: GET
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null) return View("NotFound"); // gọi view NotFound.cshtml
            return View(student);
        }

        // UPDATE: POST
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // DELETE: GET
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null) return View("NotFound"); // gọi view NotFound.cshtml
            return View(student);
        }

        // DELETE: POST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
