using System;
using System.Collections.Generic;

namespace Source.Core.Models
{
    public class TrainingDay
    {
        public string Name { get; set; }
        public int DayOfWeek { get; set; }
        public IList<TrainingSession> Sessions { get; set; }
    }
}