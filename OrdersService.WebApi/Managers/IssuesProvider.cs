using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OrdersService.WebApi.Models;

namespace OrdersService.WebApi.Managers
{
    public sealed class IssuesProvider : IIssuesProvider
    {
        private readonly HttpClient _httpClient;
        private readonly string _searchUrl;

        public IssuesProvider(
            HttpClient httpClient,
            IConfiguration configuration
        )
        {
            _httpClient = httpClient;

            _searchUrl = configuration["SearchUrl"];
        }

        public async Task<IssueReadModel[]> Search(string query)
        {
            var url = string.Format(_searchUrl, HttpUtility.UrlEncode(query));

            var message = await _httpClient
                                .GetAsync(url)
                                .ConfigureAwait(false);

            message.EnsureSuccessStatusCode();

            var content = await message.Content.ReadAsStringAsync().ConfigureAwait(false);

            var collection = JsonConvert.DeserializeObject<IssuesCollection>(content);

            return collection
                   .Issues
                   .Select(x => new IssueReadModel
                   {
                       Id = x.Id,
                       Summary = x.Fields.Summary
                   })
                   .ToArray();
        }

        // ReSharper disable once ClassNeverInstantiated.Local
        private sealed class IssuesCollection
        {
            public readonly Issue[] Issues;

            public IssuesCollection(Issue[] issues)
            {
                Issues = issues;
            }
        }

        // ReSharper disable once ClassNeverInstantiated.Local
        private sealed class Issue
        {
            public readonly FieldsCollection Fields;
            public readonly string Id;

            // ReSharper disable once UnusedMember.Global
            // ReSharper disable once UnusedMember.Local
            public Issue(string id, FieldsCollection fields)
            {
                Id = id;
                Fields = fields;
            }
        }

        // ReSharper disable once ClassNeverInstantiated.Local
        private sealed class FieldsCollection
        {
            public readonly string Summary;

            // ReSharper disable once UnusedMember.Global
            // ReSharper disable once UnusedMember.Local
            public FieldsCollection(string summary)
            {
                Summary = summary;
            }
        }
    }
}
