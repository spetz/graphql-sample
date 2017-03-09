using Graphql.Api.Core.Models;
using Graphql.Api.Core.Services;
using GraphQL.Types;

namespace Graphql.Api.Core.Types
{
    public class ExerciseType : ObjectGraphType<Exercise>
    {
        public ExerciseType(ITrainingPlanGraphQLService service)
        {
            Name = "Exercise";
            Description = "Exercise description.";        
            Field(h => h.Name).Description("Name of the exercise."); 
            Field(h => h.Number).Description("Number of the exercise in a session.");          
            Field<ListGraphType<ExerciseSetType>>(
                "sets",
                resolve: ctx => service.GetSets(ctx.Source.Id)
            );                  
        }
    }
}