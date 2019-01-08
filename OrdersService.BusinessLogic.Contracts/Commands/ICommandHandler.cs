using System.Threading.Tasks;

namespace OrdersService.BusinessLogic.Contracts.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task<string> ExecuteAsync(TCommand command);
    }
}
