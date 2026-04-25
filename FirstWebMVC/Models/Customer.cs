using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required, StringLength(50)]
        public string CustomerName { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Email { get; set; } = string.Empty;

        // Một khách hàng có nhiều đơn hàng
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
