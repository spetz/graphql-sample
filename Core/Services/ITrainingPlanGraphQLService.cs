using System;
using System.Collections.Generic;
using Graphql.Api.Core.Models;

namespace Graphql.Api.Core.Services
{
    public interface ITrainingPlanGraphQLService
    {
        TrainingPlan GetPlan(string name);
        IEnumerable<TrainingWeek> GetWeeks(Guid planId);
        IEnumerable<TrainingDay> GetDays(Guid weekId);
        IEnumerable<TrainingSession> GetSessions(Guid dayId);
        IEnumerable<Exercise> GetExercises(Guid sessionId);
        IEnumerable<ExerciseSet> GetSets(Guid exerciseId);
    }
}