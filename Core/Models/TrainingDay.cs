using System;
using System.Collections.Generic;

namespace Graphql.Api.Core.Models
{
    public class TrainingDay
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DayOfWeek { get; set; }
        public IList<TrainingSession> Sessions { get; set; }
    }
}