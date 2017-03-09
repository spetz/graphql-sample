using System;
using System.Collections.Generic;

namespace Graphql.Api.Core.Models
{
    public class TrainingPlan
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<TrainingWeek> Weeks { get; set; }
    }
}