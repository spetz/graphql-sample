using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Graphql.Api.Queries;
using Graphql.Api.Core.Services;

namespace Graphql.Api.Controllers
{
    [Route("graphql")]
    public class GraphQLController : Controller
    {
        private readonly IGraphQLProcessor _processor;

        public GraphQLController(IGraphQLProcessor processor)
        {
            _processor = processor;
        }

        [HttpPost]
        public async Task<object> PostAsync([FromBody]GraphQLQuery query)
            => await _processor.ProcessAsync(query);
    }
}
