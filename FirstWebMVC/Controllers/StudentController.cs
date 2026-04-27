using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Data;
using FirstWebMVC.Models;
using FirstWebMVC.ViewModels;   // để dùng StudentFacultyViewModel
using OfficeOpenXml;           // để đọc Excel bằng EPPlus
using System.IO;
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
                           Id = s.Id,
                           StudentCode = s.StudentCode,
                           FullName = s.FullName,
                           Age = s.Age,
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
            if (student == null) return NotFound();
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
            if (student == null) return NotFound();
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

        // UPLOAD: GET
        public IActionResult Upload()
        {
            return View();
        }

        // UPLOAD: POST - đọc Excel và lưu vào DB
        [HttpPost]
        public IActionResult UploadExcelFile()
        {
            var file = Request.Form.Files[0];
            if (file != null && file.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        var worksheet = package.Workbook.Worksheets[0];
                        int rowCount = worksheet.Dimension.Rows;

                        for (int row = 2; row <= rowCount; row++) // bỏ qua header
                        {
                            string studentCode = worksheet.Cells[row, 1].Text;
                            string fullName = worksheet.Cells[row, 2].Text;
                            int age = int.Parse(worksheet.Cells[row, 3].Text);
                            string facultyName = worksheet.Cells[row, 4].Text;

                            var faculty = _context.Faculties
                                .FirstOrDefault(f => f.FacultyName == facultyName);

                            if (faculty != null)
                            {
                                var student = new Student
                                {
                                    StudentCode = studentCode,
                                    FullName = fullName,
                                    Age = age,
                                    FacultyID = faculty.FacultyID
                                };
                                _context.Students.Add(student);
                            }
                        }
                        _context.SaveChanges();
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
