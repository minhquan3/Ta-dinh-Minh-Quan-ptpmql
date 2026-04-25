namespace FirstWebMVC.Models
{
    public class Student
    {
        public int Id { get; set; } // Khóa chính

        // Khởi tạo mặc định để tránh cảnh báo
        public string StudentCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }
}
