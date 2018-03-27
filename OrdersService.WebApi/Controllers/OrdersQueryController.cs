using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrdersService.WebApi.Managers;

namespace OrdersService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrdersQueryController : Controller
    {
        private readonly IOrdersPresenter _ordersPresenter;

        public OrdersQueryController(IOrdersPresenter ordersPresenter)
        {
            _ordersPresenter = ordersPresenter;
        }

        [HttpGet("list/{page:int?}")]
        public async Task<OkObjectResult> GetByPage(int? page)
        {
            var result = await _ordersPresenter.GetByPageAsync(page ?? 1);

            return Ok(result);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            var model = await _ordersPresenter.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }
    }
}