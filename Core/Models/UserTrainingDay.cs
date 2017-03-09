using System;
using System.Collections.Generic;

namespace Graphql.Api.Core.Models
{
    public class UserTrainingDay
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DayOfWeek { get; set; }
        public DateTime TrainingDate { get; set; }
        public bool IsCompleted { get; set; }
        public IList<UserTrainingSession> Sessions { get; set; }
    }
}