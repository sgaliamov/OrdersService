using Microsoft.AspNetCore.Mvc;
using OrdersService.WebApi.Models;

namespace OrdersService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrdersCommandController : Controller
    {
        [HttpPut("{id}")]
        public OkObjectResult Put(string id, [FromBody] OrderInputModel data)
        {
            return Ok(new { id });
        }
    }
}