using OrdersService.BusinessLogic.Commands;

namespace OrdersService.BusinessLogic.CommandHandlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}
