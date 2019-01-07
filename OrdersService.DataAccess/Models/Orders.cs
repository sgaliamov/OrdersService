using System;

namespace OrdersService.DataAccess.Models
{
    public sealed class Orders
    {
        public string Address { get; set; }
        public DateTimeOffset CreationTimestamp { get; set; }
        public string CustomerName { get; set; }

        public string DisplayId { get; set; }
        public long Id { get; set; }
        public decimal Price { get; set; }
        public byte[] Version { get; set; }
    }
}
