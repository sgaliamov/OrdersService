using AutoMapper;
using OrdersService.BusinessLogic.Commands;
using OrdersService.BusinessLogic.Contracts.Commands;
using OrdersService.BusinessLogic.Contracts.Persistance;
using Serilog;

namespace OrdersService.BusinessLogic.CommandHandlers
{
    public class AddOrderCommandHandler : ICommandHandler<AddOrderCommand>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IOrdersRepository _ordersRepository;

        public AddOrderCommandHandler(
            IOrdersRepository ordersRepository,
            IMapper mapper,
            ILogger logger)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public void Execute(AddOrderCommand command)
        {
            _logger.Information("Processing add command: {@command}", command);

            _ordersRepository.AddOrUpdateAsync(_mapper.Map<OrderEntity>(command));

            _logger.Information("Add command finished");
        }
    }
}