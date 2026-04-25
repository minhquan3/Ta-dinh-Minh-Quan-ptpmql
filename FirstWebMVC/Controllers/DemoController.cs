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
    }
}
