namespace FirstWebMVC.ViewModels
{
    public class StudentFacultyViewModel
    {
        public int Id { get; set; }              // thêm để hiển thị Id
        public string StudentCode { get; set; }  // mã sinh viên
        public string FullName { get; set; }     // họ tên
        public int Age { get; set; }             // thêm để hiển thị tuổi
        public string FacultyName { get; set; }  // tên khoa
    }
}
