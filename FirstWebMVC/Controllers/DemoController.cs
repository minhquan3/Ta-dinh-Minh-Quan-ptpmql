using Microsoft.AspNetCore.Mvc;

namespace FirstWebMVC.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            string message = "Hello Nguyễn Văn A - 123456";
            return Content(message);
        }

        public IActionResult ShowMessage()
        {
            ViewBag.Message = "Xin chào từ Controller qua ViewBag!";
            ViewBag.StudentName = "Nguyễn Văn A";
            ViewBag.StudentCode = "123456";
            return View();
        }
    }
}
[HttpGet]
public IActionResult InputName()
{
    return View();
}

[HttpPost]
public IActionResult InputName(string fullName)
{
    ViewBag.Greeting = "Xin chào " + fullName;
    return View();
}

