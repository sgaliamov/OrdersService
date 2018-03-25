using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace OrdersService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrdersCommandController : Controller
    {
        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}