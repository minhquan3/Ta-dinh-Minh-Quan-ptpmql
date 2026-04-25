using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class Faculty
    {
        public int FacultyID { get; set; }

        [Required]
        [StringLength(50)]
        public string FacultyName { get; set; } = string.Empty;

        // Một khoa có nhiều sinh viên
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
