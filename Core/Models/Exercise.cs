using System.Collections.Generic;

namespace Source.Core.Models
{
    public class Exercise
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public IList<ExerciseSet> Sets { get; set; }
    }
}