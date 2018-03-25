using System.Threading.Tasks;
using OrdersService.BusinessLogic.Contracts.Commands;

namespace OrdersService.BusinessLogic
{
    public interface ICommandDispatcher
    {
        Task<string> ExecuteAsync<T>(T command) where T : ICommand;
    }
}
