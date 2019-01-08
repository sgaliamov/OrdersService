using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace OrdersService.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IssuesController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _searchUrl;

        public IssuesController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;

            _searchUrl = configuration["SearchUrl"];
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult> Get(string orderId)
        {
            if (orderId == null)
            {
                return BadRequest("Order id is not defined.");
            }

            var url = string.Format(_searchUrl, HttpUtility.UrlEncode(orderId));
            var message = await _httpClient
                                .GetAsync(url)
                                .ConfigureAwait(false);

            return Ok(message.Content.ReadAsStringAsync());
        }
    }
}
