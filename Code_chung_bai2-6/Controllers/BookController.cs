using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _repo;

        public BookController(BookRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var books = _repo.GetAll();
            return View(books);
        }

        public IActionResult Detail(int id)
        {
            var book = _repo.GetById(id);
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

            _repo.Add(book);
            TempData["Message"] = "Thêm sách thành công!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _repo.GetById(id);
            if (book == null)
                return NotFound();
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (!ModelState.IsValid)
                return View(book);

            var updated = _repo.Update(book);
            if (!updated)
                return NotFound();

            TempData["Message"] = "Cập nhật sách thành công!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = _repo.GetById(id);
            if (book == null)
                return NotFound();
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var deleted = _repo.Delete(id);
            if (!deleted)
                return NotFound();

            TempData["Message"] = "Xóa sách thành công!";
            return RedirectToAction("Index");
        }
    }
}
