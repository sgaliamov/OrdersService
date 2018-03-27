using OrdersService.BusinessLogic.Contracts;

namespace OrdersService.WebApi.Models
{
    public interface IOrdersPresenter
    {
        Paged<OrderReadModel[]> GetByPage(int page);
        OrderReadModel GetById(string id);
    }
}