using System;
using System.Collections.Generic;
using System.Linq;
using Graphql.Api.Core.Models;

namespace Graphql.Api.Core.Services
{
    public class TrainingPlanGraphQLService : ITrainingPlanGraphQLService
    {
        private readonly IDatabase _database;

        public TrainingPlanGraphQLService(IDatabase database)
        {
            _database = database;
        }

        public TrainingPlan GetPlan(string name)
            => _database.TrainingPlans
                .FirstOrDefault(x => x.Name.ToLowerInvariant() == name.Trim().ToLowerInvariant());

        public IEnumerable<TrainingWeek> GetWeeks(Guid planId)
            => _database.TrainingPlans
                .Where(x => x.Id == planId)
                .SelectMany(x => x.Weeks);
        public IEnumerable<TrainingDay> GetDays(Guid weekId)
            => _database.TrainingPlans
                .SelectMany(x => x.Weeks)
                .Where(x => x.Id == weekId)
                .SelectMany(x => x.Days);

        public IEnumerable<TrainingSession> GetSessions(Guid dayId)
            => _database.TrainingPlans
                .SelectMany(x => x.Weeks)
                .SelectMany(x => x.Days)
                .Where(x => x.Id == dayId)
                .SelectMany(x => x.Sessions);

        public IEnumerable<Exercise> GetExercises(Guid sessionId)
            => _database.TrainingPlans
                .SelectMany(x => x.Weeks)
                .SelectMany(x => x.Days)
                .SelectMany(x => x.Sessions)
                .Where(x => x.Id == sessionId)
                .SelectMany(x => x.Exercises);

        public IEnumerable<ExerciseSet> GetSets(Guid exerciseId)
            => _database.TrainingPlans
                .SelectMany(x => x.Weeks)
                .SelectMany(x => x.Days)
                .SelectMany(x => x.Sessions)
                .SelectMany(x => x.Exercises)
                .Where(x => x.Id == exerciseId)
                .SelectMany(x => x.Sets);
    }
}