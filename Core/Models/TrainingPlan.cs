using System;
using System.Collections.Generic;

namespace Source.Core.Models
{
    public class TrainingPlan
    {
        public string Name { get; set; }
        public IList<TrainingWeek> Weeks { get; set; }
    }
}