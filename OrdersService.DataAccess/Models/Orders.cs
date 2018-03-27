using System;

namespace OrdersService.DataAccess.Models
{
    public class Orders
    {
        public long Id { get; set; }
        public DateTimeOffset CreationTimestamp { get; set; }
        public byte[] Version { get; set; }
        public string DisplayId { get; set; }
        public decimal Price { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
    }
}