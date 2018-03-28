using System.Threading.Tasks;
using OrdersService.BusinessLogic.Contracts.DomainModels;

namespace OrdersService.BusinessLogic.Contracts.Persistance
{
    public interface IOrdersRepository
    {
        Task<OrderEntity> GetByIdAsync(string id);
        Task<Paged<OrderEntity[]>> GetByPageAsync(int page);
        Task AddOrUpdateAsync(OrderEntity entity);
    }
}