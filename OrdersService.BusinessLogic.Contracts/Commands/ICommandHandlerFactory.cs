namespace OrdersService.BusinessLogic.Contracts.Commands
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<TCommand> Resolve<TCommand>() where TCommand : ICommand;
    }
}
