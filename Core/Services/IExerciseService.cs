using System.Collections.Generic;

namespace Source.Core.Services
{
    public interface IExerciseService
    {
         IEnumerable<string> GetAll();
         void Create(string exercise);
    }
}