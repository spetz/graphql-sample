using System.Threading.Tasks;
using Graphql.Api.Core.Schemas;
using Graphql.Api.Queries;
using GraphQL;
using GraphQL.Http;
using GraphQL.Instrumentation;
using GraphQL.Types;
using GraphQL.Validation.Complexity;

namespace Graphql.Api.Core.Services
{
    public class GraphQLProcessor : IGraphQLProcessor
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _executer;
        private readonly IDocumentWriter _writer;

        public GraphQLProcessor(IDocumentExecuter executer,
            IDocumentWriter writer, TrainingPlanSchema schema)
        {
            _executer = executer;
            _writer = writer;
            _schema = schema;
        }

        public async Task<string> ProcessAsync(GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();
            var queryToExecute = query.Query;
            var result = await _executer.ExecuteAsync(x =>
            {
                x.Schema = _schema;
                x.Query = queryToExecute;
                x.OperationName = query.OperationName;
                x.Inputs = inputs;
                x.ComplexityConfiguration = new ComplexityConfiguration { MaxDepth = 15 };
                x.FieldMiddleware.Use<InstrumentFieldsMiddleware>();
            });

            return _writer.Write(result);
        }
    }
}