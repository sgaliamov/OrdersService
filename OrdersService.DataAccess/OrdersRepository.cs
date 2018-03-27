using OrdersService.BusinessLogic.Contracts;

namespace OrdersService.DataAccess
{
    public class OrdersRepository : IOrdersRepository
    {
        public OrderEntity GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Paged<OrderEntity[]> GetByPage(int page)
        {
            throw new System.NotImplementedException();
        }
    }
}
