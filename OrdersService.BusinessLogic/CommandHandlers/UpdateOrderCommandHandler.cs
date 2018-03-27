using System.Threading.Tasks;
using AutoMapper;
using OrdersService.BusinessLogic.Commands;
using OrdersService.BusinessLogic.Contracts.Commands;
using OrdersService.BusinessLogic.Contracts.Persistance;
using Serilog;

namespace OrdersService.BusinessLogic.CommandHandlers
{
    public class UpdateOrderCommandHandler : ICommandHandler<UpdateOrderCommand>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IOrdersRepository _ordersRepository;

        public UpdateOrderCommandHandler(
            IOrdersRepository ordersRepository,
            IMapper mapper,
            ILogger logger)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task ExecuteAsync(UpdateOrderCommand command)
        {
            _logger.Information("Processing Update command: {@command}", command);

            await _ordersRepository.AddOrUpdateAsync(_mapper.Map<OrderEntity>(command));

            _logger.Information("Update command finished");
        }
    }
}