using Graphql.Api.Core.Models;
using Graphql.Api.Core.Services;
using GraphQL.Types;

namespace Graphql.Api.Core.Types
{
    public class ExerciseSetType : ObjectGraphType<ExerciseSet>
    {
        public ExerciseSetType(ITrainingPlanGraphQLService service)
        {
            Name = "Exercise";
            Description = "Exercise description.";        
            Field(h => h.Number).Description("Number of the exercise set.");      
            Field(h => h.Repetitions).Description("Repetitions of the exercise set.");   
            Field(h => h.Load).Description("Load of the exercise set.");                        
        }
    }
}