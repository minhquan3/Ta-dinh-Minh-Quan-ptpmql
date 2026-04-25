using Microsoft.AspNetCore.Mvc;

namespace BaiThucHanhSo3.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            string message = "Hello TẠ Đình Minh Quân 2121050256";
            return Content(message);
        }
    }
}
