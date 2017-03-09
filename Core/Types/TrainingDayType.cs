using Graphql.Api.Core.Models;
using Graphql.Api.Core.Services;
using GraphQL.Types;

namespace Graphql.Api.Core.Types
{
    public class TrainingDayType : ObjectGraphType<TrainingDay>
    {
        public TrainingDayType(ITrainingPlanGraphQLService service)
        {
            Name = "Training day";
            Description = "Training day description.";        
            Field(h => h.Name).Description("Name of the day."); 
            Field(h => h.DayOfWeek).Description("Number of the day in a week.");  
            Field<ListGraphType<TrainingSessionType>>(
                "sessions",
                resolve: ctx => service.GetSessions(ctx.Source.Id)
            );                          
        }
    }
}