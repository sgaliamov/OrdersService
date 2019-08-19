using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdersService.BusinessLogic.Contracts.DomainModels;
using OrdersService.WebApi.Managers;
using OrdersService.WebApi.Models;

namespace OrdersService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public sealed class OrdersQueryController : Controller
    {
        private readonly IOrdersPresenter _ordersPresenter;

        public OrdersQueryController(IOrdersPresenter ordersPresenter)
        {
            _ordersPresenter = ordersPresenter;
        }

        [HttpGet("list/{page:int?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Paged<OrderReadModel[]>>> GetByPage(int? page)
        {
            return await _ordersPresenter.GetByPageAsync(page ?? 1).ConfigureAwait(false);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderReadModel>> GetById(string id)
        {
            var model = await _ordersPresenter.GetByIdAsync(id).ConfigureAwait(false);
            if (model == null) // todo: throw not found exception and create global filter
            {
                return NotFound();
            }

            return model;
        }
    }
}