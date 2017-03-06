using System;

namespace Source.Core.Models
{
    public class UserExerciseSet : Set
    {
        public Guid Id { get; set; }
        public bool IsCompleted { get; set; }
    }
}