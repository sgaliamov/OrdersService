using OrdersService.BusinessLogic.Contracts.Commands;

namespace OrdersService.BusinessLogic
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly ICommandHandlerFactory _factory;

        public CommandDispatcher(ICommandHandlerFactory factory)
        {
            _factory = factory;
        }

        public void Execute<T>(T command) where T : ICommand
        {
            var handler = _factory.Resolve<T>();

            handler.Execute(command);
        }
    }
}