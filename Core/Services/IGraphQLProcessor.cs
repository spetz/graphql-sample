using System.Threading.Tasks;
using Graphql.Api.Queries;

namespace Graphql.Api.Core.Services
{
    public interface IGraphQLProcessor
    {
         Task<string> ProcessAsync(GraphQLQuery query);
    }
}