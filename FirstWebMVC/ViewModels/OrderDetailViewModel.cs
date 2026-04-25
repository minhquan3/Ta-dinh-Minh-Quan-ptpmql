namespace FirstWebMVC.ViewModels
{
    public class OrderDetailViewModel
    {
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
