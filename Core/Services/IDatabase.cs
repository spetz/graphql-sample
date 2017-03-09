using System.Collections.Generic;
using Graphql.Api.Core.Models;

namespace Graphql.Api.Core.Services
{
    public interface IDatabase
    {
        ICollection<TrainingPlan> TrainingPlans { get; }
        ICollection<UserTrainingPlan> UserTrainingPlans { get; }
        ICollection<string> Exercises { get; }
    }
}