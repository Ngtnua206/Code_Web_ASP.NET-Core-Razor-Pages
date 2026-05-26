using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using System.Diagnostics;

namespace StudentManagement.Controllers
{
    public class HomeController : Controller
    {
        private const string StudentName = "Tuan Tu";
        private const string StudentEmail = "tuan.tu@example.com";
        private const string StudentNew = "Ngày xx/dd/yyyy có xảy ra 1 vụ tai nạn !";
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            ViewData["StudentName"] = StudentName;
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["StudentEmail"] = StudentEmail;
            return View();
        }
        public IActionResult New()
        {
            ViewData["StudentNew"] = StudentNew;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
