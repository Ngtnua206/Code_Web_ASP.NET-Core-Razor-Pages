using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Nguyễn Văn A", Email = "a@example.com", Phone = "0901234567", Position = "Developer" },
            new Employee { Id = 2, Name = "Trần Thị B", Email = "b@example.com", Phone = "0907654321", Position = "Designer" },
            new Employee { Id = 3, Name = "Lê Văn C", Email = "c@example.com", Phone = "0912345678", Position = "Manager" }
        };

        public IActionResult Index()
        {
            return View(employees);
        }

        public IActionResult Detail(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound();
            return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);

            employee.Id = employees.Any() ? employees.Max(e => e.Id) + 1 : 1;
            employees.Add(employee);
            TempData["Success"] = "Thêm nhân viên thành công!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound();
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);

            var index = employees.FindIndex(e => e.Id == employee.Id);
            if (index == -1)
                return NotFound();

            employees[index] = employee;
            TempData["Success"] = "Cập nhật nhân viên thành công!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound();
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
                TempData["Success"] = "Xóa nhân viên thành công!";
            }
            return RedirectToAction("Index");
        }
    }
}
