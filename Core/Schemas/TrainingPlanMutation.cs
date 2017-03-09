using GraphQL.Types;
using Graphql.Api.Core.Types;

namespace Graphql.Api.Core.Schemas
{
    public class TrainingPlanMutation : ObjectGraphType<object>
    {
        public TrainingPlanMutation()
        {
            Field<TrainingPlanType>(
                "createPlan",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: ctx => new {});              
        }
    }  
}