using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Data;
using FirstWebMVC.Models;
using FirstWebMVC.ViewModels;   // thêm namespace để dùng ViewModel
using System.Linq;

namespace FirstWebMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // READ: Hiển thị danh sách sinh viên kèm tên khoa
        public IActionResult Index()
        {
            var data = from s in _context.Students
                       join f in _context.Faculties on s.FacultyID equals f.FacultyID
                       select new StudentFacultyViewModel
                       {
                           StudentCode = s.StudentCode,
                           FullName = s.FullName,
                           FacultyName = f.FacultyName
                       };

            return View(data.ToList());
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
            if (student == null) return View("NotFound");
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
            if (student == null) return View("NotFound");
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
