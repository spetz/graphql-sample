using System;
using System.Collections.Generic;

namespace Source.Core.Models
{
    public class TrainingSession
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public IList<Exercise> Exercises { get; set; }      
    }
}