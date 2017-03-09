using System;
using System.Collections.Generic;
using System.Linq;
using Graphql.Api.Core.Models;

namespace Graphql.Api.Core.Services
{
    public class UserTrainingPlanService : IUserTrainingPlanService
    {
        private static readonly Random Random = new Random();
        private readonly IDatabase _database;

        public UserTrainingPlanService(IDatabase database)
        {
            _database = database;
        }

        public UserTrainingPlan Get(Guid id) => _database.UserTrainingPlans.Single(x => x.Id == id);

        public IEnumerable<UserTrainingPlan> GetAll() => _database.UserTrainingPlans;

        public UserTrainingPlan Create(string name, DateTime startDate)
        {
            var trainingPlan = _database.TrainingPlans.FirstOrDefault(x => x.Name == name);
            if(trainingPlan == null)
            {
                throw new Exception($"Training plan: '{name}' was not found.");
            }
            var plan = new UserTrainingPlan
            {
                Id = Guid.NewGuid(),
                Name = name,
                Weeks = new List<UserTrainingWeek>()
            };
            var weekDate = startDate.Date;
            foreach(var week in trainingPlan.Weeks)
            {
                plan.Weeks.Add(CreateWeek(week, weekDate));
                weekDate = weekDate.AddDays(7).Date;
            }
            _database.UserTrainingPlans.Add(plan);

            return plan;
        }

        private UserTrainingWeek CreateWeek(TrainingWeek trainingWeek, DateTime weekDate)
        {
            var week = new UserTrainingWeek
            {
                Id = Guid.NewGuid(),
                Number = trainingWeek.Number,
                Days = new List<UserTrainingDay>()
            };
            var previousDayOfWeek = 0;
            var trainingDate = weekDate.Date;
            foreach(var day in trainingWeek.Days)
            {
                week.Days.Add(CreateDay(day,trainingDate));
                trainingDate = trainingDate.AddDays(day.DayOfWeek - previousDayOfWeek).Date;
                previousDayOfWeek = day.DayOfWeek;
            }

            return week;
        }

        private UserTrainingDay CreateDay(TrainingDay trainingDay, DateTime trainingDate)
        {
            var day = new UserTrainingDay
            {
                Id = Guid.NewGuid(),
                Name = trainingDay.Name,
                DayOfWeek = trainingDay.DayOfWeek,
                TrainingDate = trainingDate.Date,
                Sessions = new List<UserTrainingSession>()
            };
            foreach(var session in trainingDay.Sessions)
            {
                day.Sessions.Add(CreateSession(session));
            }
            
            return day;
        }

        private UserTrainingSession CreateSession(TrainingSession trainingSession)
        {
            var session = new UserTrainingSession
            {
                Id = Guid.NewGuid(),
                Name = trainingSession.Name,
                Number = trainingSession.Number,
                Exercises = new List<UserExercise>()
            };
            foreach(var exercise in trainingSession.Exercises)
            {
                session.Exercises.Add(CreateExercise(exercise));
            }

            return session;
        }

        private UserExercise CreateExercise(Exercise trainingExercise)
        {
            var exercise = new UserExercise
            {
                Id = Guid.NewGuid(),
                Name = trainingExercise.Name,
                Number = trainingExercise.Number,
                Sets = new List<UserExerciseSet>()
            };
            foreach(var set in trainingExercise.Sets)
            {
                exercise.Sets.Add(CreateExerciseSet(set));
            }

            return exercise;
        }

        private UserExerciseSet CreateExerciseSet(ExerciseSet exerciseSet)
        {
            var set = new UserExerciseSet
            {
                Id = Guid.NewGuid(),
                Number = exerciseSet.Number,
                Repetitions = exerciseSet.Repetitions,
                Load = exerciseSet.Load
            };
            
            return set;
        }
    }
}