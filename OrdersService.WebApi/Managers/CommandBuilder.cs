using AutoMapper;
using OrdersService.BusinessLogic.Commands;
using OrdersService.WebApi.Models;

namespace OrdersService.WebApi.Managers
{
    public sealed class CommandBuilder : ICommandBuilder
    {
        private readonly IMapper _mapper;

        public CommandBuilder(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UpdateOrderCommand BuildUpdateOrderCommand(string id, OrderInputModel model)
        {
            var command = _mapper.Map<UpdateOrderCommand>(model);
            command.OrderId = id;

            return command;
        }

        public AddOrderCommand BuildAddOrderCommand(OrderInputModel model)
        {
            return _mapper.Map<AddOrderCommand>(model);
        }
    }
}
