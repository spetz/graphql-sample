using System;
using System.Collections.Generic;

namespace Graphql.Api.Core.Models
{
    public class TrainingWeek
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public IList<TrainingDay> Days { get; set; }
    }
}