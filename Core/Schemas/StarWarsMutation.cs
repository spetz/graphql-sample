using GraphQL.Types;
using Graphql.Api.Core.Types;

namespace Graphql.Api.Core.Schemas
{
    public class StarWarsMutation : ObjectGraphType<object>
    {
        public StarWarsMutation()
        {
            Field<DroidType>(
                "createDroid",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: ctx => new {});

            Field<DroidType>(
                "updateDroid",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: ctx => new {});

            Field<DroidType>(
                "deleteDroid",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: ctx => new {});                
        }
    }  
}