using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OrdersService.BusinessLogic.Contracts;
using OrdersService.WebApi.Managers;

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

        public async Task<Paged<OrderReadModel[]>> GetByPageAsync(int page)
        {
            var data = await _ordersRepository.GetByPageAsync(page);

            var models = data.Data.Select(x => _mapper.Map<OrderReadModel>(x)).ToArray();

            return new Paged<OrderReadModel[]>
            {
                Data = models,
                Total = data.Total
            };
        }

        public async Task<OrderReadModel> GetByIdAsync(string id)
        {
            var entity = await _ordersRepository.GetByIdAsync(id);

            return _mapper.Map<OrderReadModel>(entity);
        }
    }
}