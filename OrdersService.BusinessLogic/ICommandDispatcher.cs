using OrdersService.BusinessLogic.Commands;
using OrdersService.BusinessLogic.Contracts;
using OrdersService.BusinessLogic.Contracts.Commands;

namespace OrdersService.BusinessLogic
{
    public interface ICommandDispatcher
    {
        void Execute<T>(T command) where T : ICommand;
    }
}