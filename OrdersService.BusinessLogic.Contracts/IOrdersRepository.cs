namespace OrdersService.BusinessLogic.Contracts
{
    public interface IOrdersRepository
    {
        OrderEntity GetById(string id);
        Paged<OrderEntity[]> GetByPage(int page);
    }
}