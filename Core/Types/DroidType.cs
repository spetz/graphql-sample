using GraphQL.Types;
using Graphql.Api.Core.Models;
using Graphql.Api.Core.Repositories;

namespace Graphql.Api.Core.Types
{
    public class DroidType : ObjectGraphType<Droid>
    {
        public DroidType(StarWarsRepository repository)
        {
            Name = "Droid";
            Description = "A mechanical creature in the Star Wars universe.";
            Field(d => d.Id).Description("The id of the droid.");
            Field(d => d.Name, nullable: true).Description("The name of the droid.");
            Field<ListGraphType<CharacterInterface>>(
                "friends",
                resolve: ctx => repository.GetFriends(ctx.Source));
            Field<ListGraphType<EpisodeEnum>>("appearsIn", "Which movie they appear in.");
            Field(d => d.PrimaryFunction, nullable: true).Description("The primary function of the droid.");
            Interface<CharacterInterface>();
        }
    }
}