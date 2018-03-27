using System.Threading.Tasks;

namespace OrdersService.BusinessLogic.Contracts
{
    public interface IOrdersRepository
    {
        Task<OrderEntity> GetByIdAsync(string id);
        Task<Paged<OrderEntity[]>> GetByPageAsync(int page);
        Task AddOrUpdateAsync(OrderEntity entity);
    }
}