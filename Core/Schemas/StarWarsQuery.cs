using GraphQL.Types;
using Graphql.Api.Core.Types;
using Source.Core.Repositories;

namespace Graphql.Api.Core.Schemas
{
    public class StarWarsQuery : ObjectGraphType<object>
    {
        public StarWarsQuery(StarWarsRepository repository)
        {
            Name = "StarWarsQuery";
            Field<CharacterInterface>("hero", resolve: context => repository.GetDroidByIdAsync("3"));
            Field<HumanType>(
                "human",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the human" }
                ),
                resolve: context => repository.GetHumanByIdAsync(context.GetArgument<string>("id"))
            );
            Field<DroidType>(
                "droid",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the droid" }
                ),
                resolve: context => repository.GetDroidByIdAsync(context.GetArgument<string>("id"))
            );
        }
    }
}