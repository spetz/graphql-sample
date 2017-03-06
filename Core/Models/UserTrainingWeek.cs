using System;
using System.Collections.Generic;

namespace Source.Core.Models
{
    public class UserTrainingWeek
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public bool IsCompleted { get; set; }
        public IList<UserTrainingDay> Days { get; set; }
    }
}