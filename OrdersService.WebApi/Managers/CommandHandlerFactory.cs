using System;
using OrdersService.BusinessLogic.Contracts.Commands;

namespace OrdersService.WebApi.Managers
{
    public sealed class CommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandHandlerFactory(IServiceProvider provider)
        {
            _serviceProvider = provider;
        }

        public ICommandHandler<TCommand> Resolve<TCommand>() where TCommand : ICommand
        {
            return (ICommandHandler<TCommand>)_serviceProvider.GetService(typeof(ICommandHandler<TCommand>));
        }
    }
}
