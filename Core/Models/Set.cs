using System;

namespace Graphql.Api.Core.Models
{
    public abstract class Set
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public int Repetitions { get; set; }
        public double Load { get; set; }
    }
}