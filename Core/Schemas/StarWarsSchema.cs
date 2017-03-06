using System;
using GraphQL.Types;

namespace Graphql.Api.Core.Schemas
{
    public class StarWarsSchema : Schema
    {
        public StarWarsSchema(Func<Type, GraphType> resolve) : base(resolve)
        {
            Query = (StarWarsQuery)resolve(typeof(StarWarsQuery));
            Mutation = (StarWarsMutation)resolve(typeof(StarWarsMutation));
        }
    }
}