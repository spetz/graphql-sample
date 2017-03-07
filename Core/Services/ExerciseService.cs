using System.Collections.Generic;

namespace Source.Core.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IDatabase _database;

        public ExerciseService(IDatabase database)
        {
            _database = database;
        }

        public IEnumerable<string> GetAll() => _database.Exercises;

        public void Create(string exercise)
            => _database.Exercises.Add(exercise);        
    }
}