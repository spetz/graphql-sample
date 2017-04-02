using GraphQL.Types;
using Graphql.Api.Core.Types;
using Graphql.Api.Core.Services;

namespace Graphql.Api.Core.Schemas
{
    public class TrainingPlanQuery : ObjectGraphType<object>
    {
        public TrainingPlanQuery(ITrainingPlanService trainingPlanService)
        {
            Field<ListGraphType<TrainingPlanType>>(
                "plans",
                resolve: context => trainingPlanService.GetAll()
            );
            Field<TrainingPlanType>(
                "plan",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name", Description = "Name of the training plan" }
                ),
                resolve: context => trainingPlanService.Get(context.GetArgument<string>("name"))
            );
        }
    }
}