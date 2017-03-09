using System;
using System.Collections.Generic;

namespace Graphql.Api.Core.Models
{
    public class TrainingSession
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public IList<Exercise> Exercises { get; set; }      
    }
}