using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OrdersService.WebApi.Models;

namespace OrdersService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrdersQueryController : Controller
    {
        [HttpGet]
        public IEnumerable<OrderReadModel> Get()
        {
            return Enumerable.Range(0, 100)
                .Select(GetOrderReadModel)
                .ToArray();
        }

        [HttpGet("{id}")]
        public OrderReadModel Get(int id)
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