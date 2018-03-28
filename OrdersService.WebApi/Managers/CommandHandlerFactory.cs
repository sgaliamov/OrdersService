using System;
using Microsoft.Extensions.DependencyInjection;
using OrdersService.BusinessLogic.Contracts.Commands;

namespace OrdersService.WebApi.Managers
{
    public class CommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandHandlerFactory(IServiceProvider provider)
        {
            _serviceProvider = provider;
        }

        public ICommandHandler<TCommand> Resolve<TCommand>() where TCommand : ICommand
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                return (ICommandHandler<TCommand>) scope.ServiceProvider.GetService(typeof(ICommandHandler<TCommand>));
            }
        }
    }
}