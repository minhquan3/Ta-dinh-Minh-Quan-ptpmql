using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        // FK tới Customer
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        // Một đơn hàng có nhiều chi tiết
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
