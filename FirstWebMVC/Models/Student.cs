namespace FirstWebMVC.Models
{
    public class Student
    {
        public int Id { get; set; } // Khóa chính
        public string StudentCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }
}
