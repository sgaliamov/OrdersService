using OrdersService.BusinessLogic.Contracts;
using OrdersService.BusinessLogic.Contracts.Commands;

namespace OrdersService.BusinessLogic.Commands
{
    public class UpdateOrderCommand : ICommand
    {
        public string Id { get; set; }
        public double Price { get; set; }
        public string Address { get; set; }
        public string CustomerName { get; set; }
    }
}
