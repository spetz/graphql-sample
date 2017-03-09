using System.Collections.Generic;
using Graphql.Api.Core.Models;

namespace Graphql.Api.Core.Services
{
    public interface ITrainingPlanService
    {
        TrainingPlan Get(string name);
        IEnumerable<TrainingPlan> GetAll();
        TrainingPlan Create(string name, int weeks, int daysBreak);
    }
}