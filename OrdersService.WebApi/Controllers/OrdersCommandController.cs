using Microsoft.AspNetCore.Mvc;
using OrdersService.BusinessLogic;
using OrdersService.WebApi.Managers;
using OrdersService.WebApi.Models;

namespace OrdersService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrdersCommandController : Controller
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
        public ActionResult Update(string id, [FromBody] OrderInputModel data)
        {
            var command = _commandBuilder.BuildUpdateOrderCommand(id, data);

            _commandDispatcher.Execute(command);

            return Ok(new {id});
        }

        [HttpPost]
        public ActionResult Create([FromBody] OrderInputModel data)
        {
            var command = _commandBuilder.BuildAddOrderCommand(data);

            _commandDispatcher.Execute(command);

            return Ok();
        }
    }
}