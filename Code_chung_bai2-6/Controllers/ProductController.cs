using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Detail(int? id)
        {
            if (id is null)
            {
                ViewBag.Message = "Lỗi: Bạn chưa truyền Product ID.";
                ViewBag.IsError = true;
                return View("Detail");
            }

            ViewBag.Message = $"Product ID = {id}";
            ViewBag.IsError = false;
            return View("Detail");
        }

        public IActionResult Category(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                ViewBag.Message = "Lỗi: Bạn chưa truyền tên Category.";
                ViewBag.IsError = true;
                return View("Category");
            }

            ViewBag.Message = $"Category = {name}";
            ViewBag.IsError = false;
            return View("Category");
        }
    }
}
