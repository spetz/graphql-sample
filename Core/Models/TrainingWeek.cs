using System;
using System.Collections.Generic;

namespace Source.Core.Models
{
    public class TrainingWeek
    {
        public int Number { get; set; }
        public IList<TrainingDay> Days { get; set; }
    }
}