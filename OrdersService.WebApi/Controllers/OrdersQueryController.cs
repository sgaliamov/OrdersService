using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<OrderReadModel[]>> GetByPage(int? page)
        {
            var result = await _ordersPresenter.GetByPageAsync(page ?? 1).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<OrderReadModel>> GetById(string id)
        {
            var model = await _ordersPresenter.GetByIdAsync(id).ConfigureAwait(false);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }
    }
}
