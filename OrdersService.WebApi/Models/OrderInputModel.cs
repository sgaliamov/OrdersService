using System.ComponentModel.DataAnnotations;

namespace OrdersService.WebApi.Models
{
    public sealed class OrderInputModel
    {
        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; set; }

        [Required]
        [MaxLength(260)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Number { get; set; }

        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(32)]
        public string PostCode { get; set; }

        [Required]
        [Range(0, double.PositiveInfinity)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(100)]
        public string Street { get; set; }
    }
}
