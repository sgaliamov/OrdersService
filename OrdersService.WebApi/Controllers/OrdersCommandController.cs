using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdersService.BusinessLogic;
using OrdersService.WebApi.Managers;
using OrdersService.WebApi.Models;

namespace OrdersService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public sealed class OrdersCommandController : Controller
    {
        private readonly ICommandBuilder _commandBuilder;
        private readonly ICommandDispatcher _commandDispatcher;

        public OrdersCommandController(
            ICommandBuilder commandBuilder,
            ICommandDispatcher commandDispatcher)
        {
            _commandBuilder = commandBuilder;
            _commandDispatcher = commandDispatcher;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IdField>> Update(string id, [FromBody] OrderInputModel data)
        {
            var command = _commandBuilder.BuildUpdateOrderCommand(id, data);

            var orderId = await _commandDispatcher.ExecuteAsync(command).ConfigureAwait(false);

            return new IdField { Id = orderId };
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IdField>> Create([FromBody] OrderInputModel data)
        {
            var command = _commandBuilder.BuildAddOrderCommand(data);

            var orderId = await _commandDispatcher.ExecuteAsync(command).ConfigureAwait(false);

            return new IdField { Id = orderId };
        }
    }
}