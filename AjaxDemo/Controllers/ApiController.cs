using AjaxDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Unicode;

namespace AjaxDemo.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;
        private readonly IWebHostEnvironment _host;

        public ApiController(DemoContext context,IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
        }
        public IActionResult Index(string name,int age=20)
        {
            System.Threading.Thread.Sleep(3500);   //延遲5秒再執行
            if (string.IsNullOrEmpty(name))
            {
                
                name = "Ajax";
            }
           
            return Content($"Hello, {name},You are {age} years old。", "text/plain", Encoding.UTF8);
        } //content的參數有三種，1.字串或數字，2.資料型別，3.用什麼編碼，如果字串裡面有中文，但沒有設utf8，網頁會出現亂碼
        
        
        
        public IActionResult Register(Member member, IFormFile photo)
        {
            DemoContext db = new DemoContext();

            //D:\MSIT45Site\wwwroot\uploads\2.png  不要寫死在程式中，因為部屬到網路後會出現問題，找不到路徑，要用動態方式找路徑
            //實際路徑
            string fileName = photo.FileName;
            string filePath = Path.Combine(_host.WebRootPath, "uploads", fileName);  //結合路徑、資料夾，及檔名
            //檔案上傳到uploads資料夾中
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                photo.CopyTo(fileStream);
            }//把檔案丟到photo,fileStream，fileStream匯會根據filePath, FileMode.Create做相關設定


            member.FileName = fileName;   //寫入資料庫
            //將圖轉成二進位
            byte[]? imgByte = null;
            using (var memoryStream = new MemoryStream())
            {
                photo.CopyTo(memoryStream);
                imgByte = memoryStream.ToArray();
            }
            member.FileData = imgByte;   //一樣寫進資料庫

            //將會員資料寫進資料庫
            db.Members.Add(member);
            db.SaveChanges();
               

            //return Content($"Hello, {member.Name}, You are {member.Age} years old, {member.Email}。", "text/plain", Encoding.UTF8);
            // return Content($"{photo.FileName}-{photo.Length}-{photo.ContentType}", "text/plain", Encoding.UTF8);
            // return Content($"{_host.WebRootPath} - {_host.ContentRootPath}"); //D:/MSIT45site\\wwwroot靜態資料夾 - D:/MSIT45site專案資料夾
            return Content($"{filePath}");
            
        }



    }
}
