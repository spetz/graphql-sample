using System;
using System.Collections.Generic;
using System.Linq;
using Source.Core.Models;

namespace Source.Core.Services
{
    public class TrainingPlanService : ITrainingPlanService
    {
        private static readonly Random Random = new Random();
        private readonly IDatabase _database;

        public TrainingPlanService(IDatabase database)
        {
            _database = database;
            AddPlans();
        }

        private void AddPlans()
        {
            if(_database.TrainingPlans.Any())
            {
                return;
            }
            _database.TrainingPlans.Add(CreatePlan("stronglifts", 30, 2));
            _database.TrainingPlans.Add(CreatePlan("smolov jr", 12, 3));
            _database.TrainingPlans.Add(CreatePlan("5x5", 20, 2));
        }

        public TrainingPlan Get(string name)
            => GetAll().FirstOrDefault(x => x.Name.ToLowerInvariant() == name.Trim().ToLowerInvariant());

        public IEnumerable<TrainingPlan> GetAll() => _database.TrainingPlans;

        private TrainingPlan CreatePlan(string name, int weeks, int daysBreak)
        {
            var plan = new TrainingPlan
            {
                Name = name,
                Weeks = new List<TrainingWeek>()
            };
            for(var i=1;i<=weeks; i++)
            {
                plan.Weeks.Add(CreateWeek(i, daysBreak));
            }

            return plan;
        }

        private TrainingWeek CreateWeek(int number, int daysBreak)
        {
            var week = new TrainingWeek
            {
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
                Number = number,
                Repetitions = repetitions,
                Load = load
            };
            
            return set;
        }
    }
}