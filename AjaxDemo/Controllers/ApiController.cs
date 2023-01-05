using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Unicode;

namespace AjaxDemo.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index(string name)
        {
            return Content("Hello, Ajax", "text/plain", Encoding.UTF8);
            if (string.IsNullOrEmpty(name))
            {
                name = "Ajax";
            }
           
            return Content($"Hello, {name}", "text/plain", Encoding.UTF8);
        } //content的參數有三種，1.字串或數字，2.資料型別，3.用什麼編碼，如果字串裡面有中文，但沒有設utf8，網頁會出現亂碼
    }
}
