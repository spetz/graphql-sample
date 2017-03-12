using GraphQL.Types;
using Graphql.Api.Core.Types;
using Graphql.Api.Core.Services;
using Graphql.Api.Core.Models;

namespace Graphql.Api.Core.Schemas
{
    public class TrainingPlanMutation : ObjectGraphType<object>
    {
        public TrainingPlanMutation(ITrainingPlanService trainingPlanService)
        {
            Field<TrainingPlanType>(
                "createPlan",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name", Description = "Name of the training plan" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "weeks", Description = "Weeks" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "daysBreak", Description = "Days break" }
                ),
                resolve: context => trainingPlanService.Create(context.GetArgument<string>("name"),
                    context.GetArgument<int>("weeks"), context.GetArgument<int>("daysBreak"))
            );        
        }
    }  
}