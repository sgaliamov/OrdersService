using OrdersService.BusinessLogic.Contracts.Commands;

namespace OrdersService.BusinessLogic.Commands
{
    public abstract class OrderCommand : ICommand
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string CustomerName { get; set; }
        public string Number { get; set; }
        public string OrderId { get; set; }
        public string Phone { get; set; }
        public string PostCode { get; set; }
        public decimal Price { get; set; }
        public string Street { get; set; }
    }
}
