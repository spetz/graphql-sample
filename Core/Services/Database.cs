using System;
using System.Collections.Generic;
using Graphql.Api.Core.Models;

namespace Graphql.Api.Core.Services
{
    public class Database : IDatabase
    {
        private static readonly ICollection<TrainingPlan> Plans = new HashSet<TrainingPlan>();
        private static readonly ICollection<UserTrainingPlan> UserPlans = new HashSet<UserTrainingPlan>();
        private static readonly ICollection<string> AvailableExercises = new HashSet<string>
            {"back squat", "front squat", "deadlift", "bench press", "military press", 
             "snatch", "clean", "barbell row", "pull up", "barbell row", "dips"};

        public ICollection<TrainingPlan> TrainingPlans => Plans;
        public ICollection<UserTrainingPlan> UserTrainingPlans => UserPlans;
        public ICollection<string> Exercises => AvailableExercises;
    }
}