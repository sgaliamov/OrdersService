using AutoMapper;
using OrdersService.BusinessLogic.Commands;
using OrdersService.BusinessLogic.Contracts;
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

        public void Execute(UpdateOrderCommand command)
        {
            _logger.Information("Processing Update command: {@command}", command);

            _ordersRepository.AddOrUpdateAsync(_mapper.Map<OrderEntity>(command));

            _logger.Information("Update command finished");
        }
    }
}