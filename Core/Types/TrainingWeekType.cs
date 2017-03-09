using Graphql.Api.Core.Models;
using Graphql.Api.Core.Services;
using GraphQL.Types;

namespace Graphql.Api.Core.Types
{
    public class TrainingWeekType : ObjectGraphType<TrainingWeek>
    {
        public TrainingWeekType(ITrainingPlanGraphQLService service)
        {
            Name = "Training week";
            Description = "Training week description.";        
            Field(h => h.Number).Description("Number of the week.");
            Field<ListGraphType<TrainingDayType>>(
                "days",
                resolve: ctx => service.GetDays(ctx.Source.Id)
            );             
        }
    }
}