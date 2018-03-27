using System.Threading.Tasks;
using OrdersService.BusinessLogic.Contracts.Commands;

namespace OrdersService.BusinessLogic
{
    public interface ICommandDispatcher
    {
        Task ExecuteAsync<T>(T command) where T : ICommand;
    }
}