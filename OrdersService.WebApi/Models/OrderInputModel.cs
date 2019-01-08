using System.ComponentModel.DataAnnotations;

namespace OrdersService.WebApi.Models
{
    public sealed class OrderInputModel
    {
        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(100)]
        public string Country { get; set; }

        [MaxLength(260)]
        public string CustomerName { get; set; }

        [MaxLength(100)]
        public string Number { get; set; }

        [MaxLength(50)]
        public string OrderId { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        [MaxLength(32)]
        public string PostCode { get; set; }

        [Range(0, double.PositiveInfinity)]
        public decimal Price { get; set; }

        [MaxLength(100)]
        public string Street { get; set; }
    }
}
