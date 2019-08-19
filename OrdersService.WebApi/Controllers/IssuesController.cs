using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdersService.WebApi.Managers;
using OrdersService.WebApi.Models;

namespace OrdersService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class IssuesController : ControllerBase
    {
        private readonly IIssuesProvider _issuesProvider;

        public IssuesController(IIssuesProvider issuesProvider)
        {
            _issuesProvider = issuesProvider;
        }

        [HttpGet("{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IssueReadModel[]>> Get(string orderId)
        {
            var result = await _issuesProvider.Search(orderId).ConfigureAwait(false);
            if (result == null)
            {
                return NotFound();
            }

            return result;
        }
    }
}