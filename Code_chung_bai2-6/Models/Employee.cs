using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên nhân viên không được để trống")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Chức vụ không được để trống")]
        public string Position { get; set; } = string.Empty;
    }
}
