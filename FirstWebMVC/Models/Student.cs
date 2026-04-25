using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Mã sinh viên bắt buộc nhập")]
        [StringLength(10, ErrorMessage = "Mã sinh viên tối đa 10 ký tự")]
        public string StudentCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Họ tên bắt buộc nhập")]
        [StringLength(50, ErrorMessage = "Họ tên tối đa 50 ký tự")]
        public string FullName { get; set; } = string.Empty;

        [Range(18, 60, ErrorMessage = "Tuổi phải từ 18 đến 60")]
        public int Age { get; set; }

        // Khóa ngoại liên kết tới Faculty
        [Required(ErrorMessage = "Phải chọn khoa")]
        public int FacultyID { get; set; }

        // Navigation property
        public Faculty Faculty { get; set; }
    }
}

