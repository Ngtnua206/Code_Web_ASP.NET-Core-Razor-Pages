using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    public class BookController : Controller
    {
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Name = "Clean Code", Price = 20 },
            new Book { Id = 2, Name = "ASP.NET MVC", Price = 15 },
            new Book { Id = 3, Name = "Design Pattern", Price = 25 }
        };

        public IActionResult Index()
        {
            return View(books);
        }

        public IActionResult Detail(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();
            return View(book);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
                return View(book);

            book.Id = books.Max(b => b.Id) + 1;
            books.Add(book);
            ViewBag.Message = "Thêm sách thành công!";
            ModelState.Clear();
            return View();
        }
    }
}
