using System.Linq;
using AutoMapper;
using OrdersService.BusinessLogic.Contracts;

namespace OrdersService.WebApi.Models
{
    public class OrdersPresenter : IOrdersPresenter
    {
        private readonly IMapper _mapper;
        private readonly IOrdersRepository _ordersRepository;

        public OrdersPresenter(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public Paged<OrderReadModel[]> GetByPage(int page)
        {
            var data = _ordersRepository.GetByPage(page);

            var models = data.Data.Select(x => _mapper.Map<OrderReadModel>(x)).ToArray();

            return new Paged<OrderReadModel[]>
            {
                Data = models,
                Total = data.Total
            };
        }

        public OrderReadModel GetById(string id)
        {
            var entity = _ordersRepository.GetById(id);

            return _mapper.Map<OrderReadModel>(entity);
        }
    }
}