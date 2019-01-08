namespace OrdersService.WebApi.Models
{
    public sealed class OrderInputModel
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string CustomerName { get; set; }
        public string Number { get; set; }
        public string Phone { get; set; }
        public string PostCode { get; set; }
        public decimal Price { get; set; }
        public string Street { get; set; }
    }
}
