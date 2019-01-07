using System;

namespace OrdersService.DataAccess.Entities
{
    public sealed class Orders
    {
        public string City { get; set; }
        public string Country { get; set; }
        public DateTimeOffset CreationTimestamp { get; set; }
        public string CustomerName { get; set; }
        public long Id { get; set; }
        public int Number { get; set; }
        public string OrderId { get; set; }
        public string Phone { get; set; }
        public string PostCode { get; set; }
        public decimal Price { get; set; }
        public string Street { get; set; }
        public byte[] Version { get; set; }
    }
}
