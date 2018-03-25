using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OrdersService.WebApi.Models;

namespace OrdersService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrdersQueryController : Controller
    {
        private const int PageSize = 5;

        [HttpGet("list/{page:int?}")]
        public OkObjectResult GetByPage(int? page)
        {
            var data = Enumerable.Range(0, 100)
                .Skip(((page ?? 1) - 1) * PageSize)
                .Take(PageSize)
                .Select(GetOrderReadModel)
                .ToArray();

            return Ok(new
            {
                data,
                total = 100
            });
        }

        [HttpGet("id/{id:int}")]
        public OrderReadModel GetById(int id)
        {
            return GetOrderReadModel(id);
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