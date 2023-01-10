using AjaxDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Unicode;

namespace AjaxDemo.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index(string name)
        {
            //System.Threading.Thread.Sleep(3500);   //延遲5秒再執行
            if (string.IsNullOrEmpty(name))
            {
                name = "Ajax";
            }
           
            return Content($"Hello, {name}", "text/plain", Encoding.UTF8);
        } //content的參數有三種，1.字串或數字，2.資料型別，3.用什麼編碼，如果字串裡面有中文，但沒有設utf8，網頁會出現亂碼

        //讀取城市名
        public IActionResult City()
        {
            DemoContext db =   new DemoContext();
            var cites = db.Addresses.Select(c => c.City).Distinct();  //陣列形式的json
            //var cites = db.Addresses.Select(c => new { c.City }).Distinct().OrderBy(c => c.City);  物件形式的json
            return Json(cites);
        }

        //根據城市名稱讀取鄉政區
        public IActionResult Site(string city)
        {
            DemoContext db = new DemoContext();
            var sites = db.Addresses.Where(s => s.City == city).Select(s => s.SiteId).Distinct();
            return Json(sites);
        }
        //根據鄉政區讀取路名
        public IActionResult Road(string site)
        {
            DemoContext db = new DemoContext();
            var roads = db.Addresses.Where(r => r.SiteId == site).Select(r => r.Road).Distinct();
            return Json(roads);
        }
    }
}

//Scaffold-DbContext "Data Source=.;Initial Catalog=Demo;Integrated Security=True;TrustServerCertificate=true;”Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models