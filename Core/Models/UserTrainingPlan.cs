using System;
using System.Collections.Generic;

namespace Source.Core.Models
{
    public class UserTrainingPlan
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public IList<UserTrainingWeek> Weeks { get; set; }        
    }
}