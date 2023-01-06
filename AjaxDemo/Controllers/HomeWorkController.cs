using Microsoft.AspNetCore.Mvc;

namespace AjaxDemo.Controllers
{
    public class HomeWorkController : Controller
    {
        public IActionResult Json()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
