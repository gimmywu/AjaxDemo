using AjaxDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace AjaxDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DemoContext _conetxt;    //在 Controller 的建構函式中注入在 Program.cs 註冊過的 NorthwindContext 物件

      
        public HomeController(ILogger<HomeController> logger, DemoContext conetxt)  //在 Controller 的建構函式中注入在 Program.cs 註冊過的 NorthwindContext 物件
        {
            _logger = logger;
            _conetxt = conetxt;
        }
        public IActionResult DemoNoCall()   //測試是否可以不用呼叫
        {
            var member = _conetxt.Members;
            return View(member);
        }



        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult FirstAjsx()
        {
            return View();
        }

    }
}