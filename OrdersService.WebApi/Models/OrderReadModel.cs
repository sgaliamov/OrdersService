namespace OrdersService.WebApi.Models
{
    public class OrderReadModel
    {
        public string Id { get; set; }
        public double Price { get; set; }
        public string Address { get; set; }
        public string CustomerName { get; set; }
    }
}