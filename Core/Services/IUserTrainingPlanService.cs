using System;
using System.Collections.Generic;
using Graphql.Api.Core.Models;

namespace Graphql.Api.Core.Services
{
    public interface IUserTrainingPlanService
    {
        IEnumerable<UserTrainingPlan> GetAll();
        UserTrainingPlan Get(Guid id);   
        UserTrainingPlan Create(string name, DateTime startDate);
    }
}