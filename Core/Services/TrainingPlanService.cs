using System;
using System.Collections.Generic;
using System.Linq;
using Graphql.Api.Core.Models;

namespace Graphql.Api.Core.Services
{
    public class TrainingPlanService : ITrainingPlanService
    {
        private static readonly Random Random = new Random();
        private readonly IDatabase _database;

        public TrainingPlanService(IDatabase database)
        {
            _database = database;
        }

        public TrainingPlan Get(string name)
            => GetAll().FirstOrDefault(x => x.Name.ToLowerInvariant() == name.Trim().ToLowerInvariant());

        public IEnumerable<TrainingPlan> GetAll() => _database.TrainingPlans;

        public TrainingPlan Create(string name, int weeks, int daysBreak)
        {
            var existingPlan = Get(name);
            if(existingPlan != null)
            {
                throw new Exception($"There is already training plan with name: '{name}'.");
            }

            var plan = new TrainingPlan
            {
                Id = Guid.NewGuid(),
                Name = name,
                Weeks = new List<TrainingWeek>()
            };
            for(var i=1;i<=weeks; i++)
            {
                plan.Weeks.Add(CreateWeek(i, daysBreak));
            }
            _database.TrainingPlans.Add(plan);

            return plan;
        }

        private TrainingWeek CreateWeek(int number, int daysBreak)
        {
            var week = new TrainingWeek
            {
                Id = Guid.NewGuid(),
                Number = number,
                Days = new List<TrainingDay>()
            };
            var dayOfWeek = 1;
            for(var i=0;i<7; i++)
            {
                if(dayOfWeek>7)
                {
                    break;
                }
                week.Days.Add(CreateDay(dayOfWeek));
                dayOfWeek+=daysBreak;
            }
            
            return week;
        }

        private TrainingDay CreateDay(int dayOfWeek)
        {
            var name = dayOfWeek == 7 ? 
                DayOfWeek.Sunday.ToString() : 
                ((DayOfWeek)(dayOfWeek)).ToString();

            var day = new TrainingDay
            {
                Id = Guid.NewGuid(),
                Name = name,
                DayOfWeek = dayOfWeek,
                Sessions = new List<TrainingSession>()
            };
            day.Sessions.Add(CreateSession("workout", 1));
            
            return day;
        }

        private TrainingSession CreateSession(string name, int number)
        {
            var session = new TrainingSession
            {
                Id = Guid.NewGuid(),
                Name = name,
                Number = number,
                Exercises = new List<Exercise>()
            };

            var addedExercises = new HashSet<string>();
            var exercise = string.Empty;
            for(var i=1;i<=Random.Next(3,8); i++)
            {
                while(string.IsNullOrWhiteSpace(exercise) || addedExercises.Contains(exercise))
                {
                    exercise = _database.Exercises.ElementAt(Random.Next(0, _database.Exercises.Count - 1));
                }
                addedExercises.Add(exercise);
                session.Exercises.Add(CreateExercise(exercise, i));
            }

            return session;
        }

        private Exercise CreateExercise(string name, int number)
        {
            var exercise = new Exercise
            {
                Id = Guid.NewGuid(),
                Name = name,
                Number = number,
                Sets = new List<ExerciseSet>()
            };

            for(var i=1;i<=Random.Next(3,8); i++)
            {
                exercise.Sets.Add(CreateExerciseSet(i, Random.Next(1,12), Random.Next(40,200)));
            }
            
            return exercise;
        }

        private ExerciseSet CreateExerciseSet(int number, int repetitions, double load)
        {
            var set = new ExerciseSet
            {
                Id = Guid.NewGuid(),
                Number = number,
                Repetitions = repetitions,
                Load = load
            };
            
            return set;
        }
    }
}