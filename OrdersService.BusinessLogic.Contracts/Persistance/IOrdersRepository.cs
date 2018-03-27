using System.Threading.Tasks;

namespace OrdersService.BusinessLogic.Contracts.Persistance
{
    public interface IOrdersRepository
    {
        Task<OrderEntity> GetByIdAsync(string id);
        Task<Paged<OrderEntity[]>> GetByPageAsync(int page);
        Task AddOrUpdateAsync(OrderEntity entity);
    }
}