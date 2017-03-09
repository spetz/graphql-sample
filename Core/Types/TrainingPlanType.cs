using Graphql.Api.Core.Models;
using Graphql.Api.Core.Services;
using GraphQL.Types;

namespace Graphql.Api.Core.Types
{
    public class TrainingPlanType : ObjectGraphType<TrainingPlan>
    {
        public TrainingPlanType(ITrainingPlanGraphQLService service)
        {
            Name = "Training plan";
            Description = "Training plan description.";        
            Field(h => h.Name).Description("The name of training plan."); 
            Field<ListGraphType<TrainingWeekType>>(
                "weeks",
                resolve: ctx => service.GetWeeks(ctx.Source.Id)
            );
        }
    }
}