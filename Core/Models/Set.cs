using System;

namespace Source.Core.Models
{
    public abstract class Set
    {
        public int Number { get; set; }
        public int Repetitions { get; set; }
        public double Load { get; set; }
    }
}