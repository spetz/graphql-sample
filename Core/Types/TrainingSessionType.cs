using Graphql.Api.Core.Models;
using Graphql.Api.Core.Services;
using GraphQL.Types;

namespace Graphql.Api.Core.Types
{
    public class TrainingSessionType : ObjectGraphType<TrainingSession>
    {
        public TrainingSessionType(ITrainingPlanGraphQLService service)
        {
            Name = "Training session";
            Description = "Training session description.";        
            Field(h => h.Name).Description("Name of the session."); 
            Field(h => h.Number).Description("Number of the session in a day.");          
            Field<ListGraphType<ExerciseType>>(
                "exercises",
                resolve: ctx => service.GetExercises(ctx.Source.Id)
            );                  
        }
    }
}