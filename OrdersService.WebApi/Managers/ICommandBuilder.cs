using OrdersService.BusinessLogic.Commands;
using OrdersService.WebApi.Models;

namespace OrdersService.WebApi.Managers
{
    public interface ICommandBuilder
    {
        UpdateOrderCommand BuildUpdateOrderCommand(string id, OrderInputModel model);
        AddOrderCommand BuildAddOrderCommand(OrderInputModel model);
    }
}