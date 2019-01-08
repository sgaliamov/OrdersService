using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrdersService.WebApi.Managers;

namespace OrdersService.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IssuesController : ControllerBase
    {
        private readonly IIssuesProvider _issuesProvider;

        public IssuesController(IIssuesProvider issuesProvider)
        {
            _issuesProvider = issuesProvider;
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult> Get(string orderId)
        {
            if (orderId == null)
            {
                return BadRequest("Order id is not defined.");
            }

            var result = await _issuesProvider.Search(orderId).ConfigureAwait(false);

            return Ok(result);
        }
    }
}
