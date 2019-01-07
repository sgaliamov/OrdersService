using System.Threading.Tasks;
using AutoMapper;
using OrdersService.BusinessLogic.Contracts.DomainModels;
using OrdersService.BusinessLogic.Contracts.Persistence;
using OrdersService.WebApi.Models;

namespace OrdersService.WebApi.Managers
{
    public sealed class OrdersPresenter : IOrdersPresenter
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
            var data = await _ordersRepository.GetByPageAsync(page).ConfigureAwait(false);

            var models = _mapper.Map<OrderReadModel[]>(data.Data);

            return new Paged<OrderReadModel[]>
            {
                Data = models,
                Total = data.Total
            };
        }

        public async Task<OrderReadModel> GetByIdAsync(string id)
        {
            var entity = await _ordersRepository.GetByIdAsync(id).ConfigureAwait(false);

            return _mapper.Map<OrderReadModel>(entity);
        }
    }
}