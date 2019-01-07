namespace OrdersService.WebApi.Models
{
    public sealed class OrderReadModel
    {
        public string Address { get; set; }
        public string CustomerName { get; set; }
        public string Id { get; set; }
        public double Price { get; set; }
    }
}
