using System.Collections.Generic;
using Source.Core.Models;

namespace Source.Core.Services
{
    public interface IDatabase
    {
         ICollection<TrainingPlan> TrainingPlans { get; }
         ICollection<UserTrainingPlan> UserTrainingPlans { get; }
         ICollection<string> Exercises { get; }
    }
}