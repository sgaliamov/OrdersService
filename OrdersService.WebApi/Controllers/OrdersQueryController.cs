using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace OrdersService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrdersQueryController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] {"value1", "value2"};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}