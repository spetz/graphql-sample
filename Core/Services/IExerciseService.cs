using System.Collections.Generic;

namespace Graphql.Api.Core.Services
{
    public interface IExerciseService
    {
        IEnumerable<string> GetAll();
        void Create(string exercise);
    }
}