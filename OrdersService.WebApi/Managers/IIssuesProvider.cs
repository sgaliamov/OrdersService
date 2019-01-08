using System.Threading.Tasks;
using OrdersService.WebApi.Models;

namespace OrdersService.WebApi.Managers
{
    public interface IIssuesProvider
    {
        Task<IssueReadModel[]> Search(string query);
    }
}
