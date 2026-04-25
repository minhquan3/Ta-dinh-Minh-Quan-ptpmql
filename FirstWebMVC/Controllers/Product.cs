using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required, StringLength(50)]
        public string ProductName { get; set; } = string.Empty;

        [Range(1, 100000)]
        public decimal Price { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
