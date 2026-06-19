using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sách không được để trống")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Giá không được để trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá không được là số âm")]
        [Precision(18, 2)]
        public decimal Price { get; set; }
    }
}
