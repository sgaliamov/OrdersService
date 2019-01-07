using System.Threading.Tasks;
using OrdersService.BusinessLogic.Contracts.DomainModels;
using OrdersService.WebApi.Models;

namespace OrdersService.WebApi.Managers
{
    public interface IOrdersPresenter
    {
        Task<Paged<OrderReadModel[]>> GetByPageAsync(int page);
        Task<OrderReadModel> GetByIdAsync(string id);
    }
}
