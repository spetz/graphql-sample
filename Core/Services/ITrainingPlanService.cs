using System.Collections.Generic;
using Source.Core.Models;

namespace Source.Core.Services
{
    public interface ITrainingPlanService
    {
         IEnumerable<TrainingPlan> GetAll();
         TrainingPlan Get(string name);
    }
}