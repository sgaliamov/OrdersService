using System.Threading.Tasks;
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
        public async Task<ActionResult> Update(string id, [FromBody] OrderInputModel data)
        {
            var command = _commandBuilder.BuildUpdateOrderCommand(id, data);

            var orderId = await _commandDispatcher.ExecuteAsync(command).ConfigureAwait(false);

            return Ok(new { id = orderId });
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] OrderInputModel data)
        {
            var command = _commandBuilder.BuildAddOrderCommand(data);

            var orderId = await _commandDispatcher.ExecuteAsync(command).ConfigureAwait(false);

            return Ok(new { id = orderId });
        }
    }
}
