namespace OrdersService.BusinessLogic.Contracts.DomainModels
{
    public sealed class OrderEntity
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CustomerName { get; set; }
        public int Number { get; set; }
        public string OrderId { get; set; }
        public string Phone { get; set; }
        public string PostCode { get; set; }
        public double Price { get; set; }
        public string Street { get; set; }
    }
}
