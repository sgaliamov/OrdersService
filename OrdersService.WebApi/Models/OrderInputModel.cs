namespace OrdersService.WebApi.Models
{
    public class OrderInputModel
    {
        public double Price { get; set; }
        public string Address { get; set; }
        public string CustomerName { get; set; }
    }
}