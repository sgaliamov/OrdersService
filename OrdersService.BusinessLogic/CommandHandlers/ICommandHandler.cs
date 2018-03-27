using OrdersService.BusinessLogic.Commands;

namespace OrdersService.BusinessLogic.CommandHandlers
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
    }
}
