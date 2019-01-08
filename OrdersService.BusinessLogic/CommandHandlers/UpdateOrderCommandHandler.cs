using System.Threading.Tasks;
using AutoMapper;
using OrdersService.BusinessLogic.Commands;
using OrdersService.BusinessLogic.Contracts.Commands;
using OrdersService.BusinessLogic.Contracts.DomainModels;
using OrdersService.BusinessLogic.Contracts.Persistence;
using Serilog;

namespace OrdersService.BusinessLogic.CommandHandlers
{
    public sealed class UpdateOrderCommandHandler : ICommandHandler<UpdateOrderCommand>
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

        public async Task<string> ExecuteAsync(UpdateOrderCommand command)
        {
            _logger.Information("Processing Update command: {@command}.", command);

            return await _ordersRepository.AddOrUpdateAsync(_mapper.Map<OrderEntity>(command)).ConfigureAwait(false);
        }
    }
}
