using System;
using System.Collections.Generic;
using Source.Core.Models;

namespace Source.Core.Services
{
    public interface IUserTrainingPlanService
    {
         IEnumerable<UserTrainingPlan> GetAll();
         UserTrainingPlan Get(Guid id);   
         void Create(string name, DateTime startDate);
    }
}