using System;
using GraphQL.Types;

namespace Graphql.Api.Core.Schemas
{
    public class TrainingPlanSchema : Schema
    {
        public TrainingPlanSchema(Func<Type, GraphType> resolve) : base(resolve)
        {
            Query = (TrainingPlanQuery)resolve(typeof(TrainingPlanQuery));
            Mutation = (TrainingPlanMutation)resolve(typeof(TrainingPlanMutation));
        }
    }
}