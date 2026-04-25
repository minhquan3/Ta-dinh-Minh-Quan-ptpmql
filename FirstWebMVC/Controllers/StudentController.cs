using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Models;

namespace FirstWebMVC.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            ViewBag.Info = $"Mã SV: {student.StudentCode}, Họ tên: {student.FullName}";
            return View();
        }
    }
}
