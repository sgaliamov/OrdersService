namespace OrdersService.WebApi.Models
{
    public sealed class OrderInputModel
    {
        public double Price { get; set; }
        public string Address { get; set; }
        public string CustomerName { get; set; }
    }
}