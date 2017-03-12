using Graphql.Api.Core.Models;
using GraphQL.Types;

namespace Graphql.Api.Core.Types
{
    public class ExerciseSetType : ObjectGraphType<ExerciseSet>
    {
        public ExerciseSetType()
        {
            Interface<SetInterface>(); 
            Field(h => h.Number).Description("Number of the set.");      
            Field(h => h.Repetitions).Description("Repetitions of the set.");   
            Field(h => h.Load).Description("Load of the set.");                          
        }
    }
}