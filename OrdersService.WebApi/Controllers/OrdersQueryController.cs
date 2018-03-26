using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OrdersService.WebApi.Models;

namespace OrdersService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrdersQueryController : Controller
    {
        private const int PageSize = 5;
        private static readonly OrderReadModel[] Data;

        static OrdersQueryController()
        {
            Data = Enumerable.Range(0, 100)
                .Select(GetOrderReadModel)
                .ToArray();
        }

        [HttpGet("list/{page:int?}")]
        public OkObjectResult GetByPage(int? page)
        {
            var data = Data
                .Skip(((page ?? 1) - 1) * PageSize)
                .Take(PageSize)
                .ToArray();

            return Ok(new
            {
                data,
                total = Data.Length
            });
        }

        [HttpGet("id/{id}")]
        public ActionResult GetById(string id)
        {
            var model = Data.FirstOrDefault(x => x.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        private static OrderReadModel GetOrderReadModel(int x)
        {
            return new OrderReadModel
            {
                Address = "Address_" + x,
                CustomerName = "CustomerName_" + x,
                Price = x * 1000,
                Id = "ID_" + x
            };
        }
    }
}