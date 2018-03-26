using Microsoft.AspNetCore.Mvc;
using OrdersService.WebApi.Models;

namespace OrdersService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrdersCommandController : Controller
    {
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] OrderInputModel data)
        {
            return Ok(id);
        }
    }
}