namespace OrdersService.WebApi.Models
{
    public sealed class OrderInputModel
    {
        public string Address { get; set; }
        public string CustomerName { get; set; }
        public double Price { get; set; }
    }
}
