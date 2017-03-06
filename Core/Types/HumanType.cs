using GraphQL.Types;
using Graphql.Api.Core.Models;
using Source.Core.Repositories;

namespace Graphql.Api.Core.Types
{
    public class HumanType : ObjectGraphType<Human>
    {
        public HumanType(StarWarsRepository repository)
        {
            Name = "Human";
            Field(h => h.Id).Description("The id of the human.");
            Field(h => h.Name, nullable: true).Description("The name of the human.");
            Field<ListGraphType<CharacterInterface>>(
                "friends",
                resolve: ctx => repository.GetFriends(ctx.Source));
            Field<ListGraphType<EpisodeEnum>>("appearsIn", "Which movie they appear in.");
            Field(h => h.HomePlanet, nullable: true).Description("The home planet of the human.");
            Interface<CharacterInterface>();
        }
    }
}