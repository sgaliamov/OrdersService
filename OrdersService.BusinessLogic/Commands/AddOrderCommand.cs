using OrdersService.BusinessLogic.Contracts.Commands;

namespace OrdersService.BusinessLogic.Commands
{
    public sealed class AddOrderCommand : ICommand
    {
        public string Address { get; set; }
        public string CustomerName { get; set; }
        public string Id { get; set; }
        public double Price { get; set; }
    }
}
