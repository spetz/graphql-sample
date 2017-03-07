using System;
using System.Collections.Generic;
using Source.Core.Models;

namespace Source.Core.Services
{
    public interface IUserTrainingPlanService
    {
         IEnumerable<UserTrainingPlan> GetAll();
         UserTrainingPlan Get(Guid id);   
         UserTrainingPlan Create(string name, DateTime startDate);
    }
}