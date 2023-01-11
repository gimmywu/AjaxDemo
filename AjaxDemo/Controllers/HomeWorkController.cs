using AjaxDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Xml.Linq;

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
        public IActionResult CheckName(string name)
        {
            string data = "";
            DemoContext db = new DemoContext();
            bool yesno = db.Members.Any(m => m.Name == name);
            if(yesno) {
                data = "這個帳號已經有人用囉~";
            }
            else
            {
                data = "此帳號可以用喔";
            }

            return Content($"{data}", "text/plain", Encoding.UTF8);
        }

        public IActionResult Address()
        {
            return View();
        }


    }
}
